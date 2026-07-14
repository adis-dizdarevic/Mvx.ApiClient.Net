using System.Collections;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Mvx.ApiClient.Net.Clients;
using Mvx.ApiClient.Net.Infrastructure;

namespace Mvx.ApiClient.Net.Test;

public sealed class CompleteGetSurfaceTest
{
    private static readonly HashSet<string> ExistingPaths =
    [
        "/stats", "/economics", "/constants", "/about",
        "/mex/economics", "/mex/pairs", "/mex/pairs/count",
        "/mex/pairs/{baseId}/{quoteId}", "/mex/tokens", "/mex/tokens/count",
        "/mex/tokens/{identifier}", "/mex/farms", "/mex/farms/count"
    ];

    private static readonly HashSet<(string Path, string Name)> UpstreamPhantomQueries =
    [
        ("/auctions/{id}", "auctionId"),
        ("/accounts/{address}/auctions/count", "address"),
        ("/collections/{collection}/auctions", "collection"),
        ("/collections/{collection}/auctions/count", "collection")
    ];

    [Test]
    public async Task EveryApprovedGet_HasExactlyOneImplementation()
    {
        var snapshot = await ReadSnapshotAsync();
        var approved = snapshot.Operations
            .Where(operation => !operation.Deprecated && operation.DocumentationStatus != "excluded")
            .ToArray();
        var implementations = GetImplementations();

        if (approved.Length != 157)
        {
            throw new InvalidOperationException($"Expected 157 approved GET operations, but the snapshot contains {approved.Length}.");
        }

        var duplicateIds = implementations
            .GroupBy(item => item.Attribute.OperationId, StringComparer.Ordinal)
            .Where(group => group.Count() != 1)
            .Select(group => group.Key)
            .ToArray();
        if (duplicateIds.Length != 0)
        {
            throw new InvalidOperationException($"GET operation IDs must map exactly once: {string.Join(", ", duplicateIds)}");
        }

        var byOperationId = implementations.ToDictionary(item => item.Attribute.OperationId, StringComparer.Ordinal);
        foreach (var operation in approved)
        {
            if (!byOperationId.TryGetValue(operation.OperationId, out var implementation))
            {
                throw new InvalidOperationException($"Missing implementation for {operation.OperationId} ({operation.Path}).");
            }

            if (!string.Equals(operation.Path, implementation.Attribute.Path, StringComparison.Ordinal))
            {
                throw new InvalidOperationException($"{operation.OperationId} maps to {implementation.Attribute.Path}, expected {operation.Path}.");
            }
        }

        var unexpected = implementations
            .Where(item => approved.All(operation => operation.OperationId != item.Attribute.OperationId))
            .Select(item => item.Attribute.OperationId)
            .ToArray();
        if (unexpected.Length != 0)
        {
            throw new InvalidOperationException($"Implementations outside the approved GET surface: {string.Join(", ", unexpected)}");
        }
    }

    [Test]
    public async Task GeneratedClients_MatchCheckedInOpenApiDocument()
    {
        var bytes = await File.ReadAllBytesAsync(Path.Combine(AppContext.BaseDirectory, "multiversx-openapi.json"));
        var actual = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        if (!string.Equals(GeneratedApiRegistration.SourceSha256, actual, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Generated GET clients do not match eng/multiversx-openapi.json. Run the GET client generator.");
        }
    }

    [Test]
    public async Task EveryGeneratedGet_EncodesItsCompleteUsefulQueryContract()
    {
        var snapshot = await ReadSnapshotAsync();
        var operations = snapshot.Operations.ToDictionary(operation => operation.OperationId, StringComparer.Ordinal);

        foreach (var implementation in GetImplementations().Where(item => !ExistingPaths.Contains(item.Attribute.Path)))
        {
            var operation = operations[implementation.Attribute.OperationId];
            Uri? requestUri = null;
            var handler = new TestHttpMessageHandler(request =>
            {
                requestUri = request.RequestUri;
                return CreateResponse(implementation.Method.ReturnType, implementation.Attribute.Path);
            });
            using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.example.test/root/") };
            var client = Activator.CreateInstance(implementation.Type, httpClient)
                ?? throw new InvalidOperationException($"Could not create {implementation.Type}.");
            var arguments = implementation.Method.GetParameters().Select(CreateArgument).ToArray();

            var invocation = implementation.Method.Invoke(client, arguments) as Task
                ?? throw new InvalidOperationException($"{implementation.Method} did not return a Task.");
            await invocation;

            if (requestUri is null)
            {
                throw new InvalidOperationException($"{implementation.Method} did not issue an HTTP request.");
            }

            AssertPath(operation, requestUri);
            AssertQuery(operation, requestUri);
        }
    }

    private static IReadOnlyList<Implementation> GetImplementations()
    {
        return typeof(MvxApiClient).Assembly.GetTypes()
            .Where(type => type.Namespace == "Mvx.ApiClient.Net.Clients")
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(method => new { Type = type, Method = method, Attribute = method.GetCustomAttribute<ApiOperationAttribute>() }))
            .Where(item => item.Attribute is not null)
            .Select(item => new Implementation(item.Type, item.Method, item.Attribute!))
            .ToArray();
    }

    private static object? CreateArgument(ParameterInfo parameter)
    {
        var type = parameter.ParameterType;
        if (type == typeof(CancellationToken))
        {
            return CancellationToken.None;
        }

        if (type == typeof(string))
        {
            return "sample value";
        }

        if (type == typeof(bool))
        {
            return true;
        }

        if (type == typeof(long))
        {
            return 7L;
        }

        if (type.IsEnum)
        {
            return Enum.GetValues(type).Cast<object>().First(value => Convert.ToInt64(value) != 0);
        }

        var options = Activator.CreateInstance(type)
            ?? throw new InvalidOperationException($"Could not create options type {type}.");
        foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            property.SetValue(options, CreatePropertyValue(property.PropertyType));
        }

        return options;
    }

    private static object? CreatePropertyValue(Type type)
    {
        var underlying = Nullable.GetUnderlyingType(type);
        if (underlying is not null)
        {
            return CreatePropertyValue(underlying);
        }

        if (type == typeof(Pagination))
        {
            return new Pagination { Limit = 2, Offset = 3 };
        }

        if (type == typeof(string))
        {
            return "sample value";
        }

        if (type == typeof(bool))
        {
            return true;
        }

        if (type is { IsPrimitive: true } || type == typeof(decimal))
        {
            return Convert.ChangeType(7, type);
        }

        if (type.IsEnum)
        {
            return Enum.GetValues(type).Cast<object>().First(value => Convert.ToInt64(value) != 0);
        }

        if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type))
        {
            var elementType = type.GetGenericArguments()[0];
            var array = Array.CreateInstance(elementType, 2);
            array.SetValue(CreateCollectionElement(elementType, 1), 0);
            array.SetValue(CreateCollectionElement(elementType, 2), 1);
            return array;
        }

        throw new InvalidOperationException($"No generated query test value is defined for {type}.");
    }

    private static object CreateCollectionElement(Type type, int index)
    {
        if (type == typeof(string))
        {
            return index == 1 ? "first value" : "second value";
        }

        if (type.IsEnum)
        {
            return Enum.GetValues(type).Cast<object>().First(value => Convert.ToInt64(value) != 0);
        }

        return Convert.ChangeType(index, type);
    }

    private static HttpResponseMessage CreateResponse(Type taskType, string path)
    {
        var resultType = taskType.GetGenericArguments()[0];
        string payload;
        if (resultType == typeof(string))
        {
            payload = path == "/hello" ? "hello" : "\"value\"";
        }
        else if (resultType == typeof(long))
        {
            payload = "0";
        }
        else if (resultType == typeof(bool))
        {
            payload = "true";
        }
        else if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>))
        {
            payload = "[]";
        }
        else
        {
            payload = "{}";
        }

        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
    }

    private static void AssertPath(ApiSurfaceOperation operation, Uri requestUri)
    {
        var expected = Regex.Replace(operation.Path, "\\{(?<name>[^}]+)\\}", match =>
        {
            var parameter = operation.Parameters.FirstOrDefault(item => item.Location == "path" && item.Name == match.Groups["name"].Value);
            return parameter?.Type is "number" or "integer" ? "7" : "sample%20value";
        });

        var actual = requestUri.AbsolutePath["/root".Length..];
        if (!string.Equals(expected, actual, StringComparison.Ordinal))
        {
            throw new InvalidOperationException($"{operation.OperationId} requested path {actual}, expected {expected}.");
        }
    }

    private static void AssertQuery(ApiSurfaceOperation operation, Uri requestUri)
    {
        var actual = ParseQuery(requestUri.Query);
        var expectedParameters = operation.Parameters
            .Where(parameter => parameter.Location == "query"
                && !parameter.Deprecated
                && parameter.Name is not ("fields" or "extract")
                && !UpstreamPhantomQueries.Contains((operation.Path, parameter.Name)))
            .ToArray();
        var expectedNames = expectedParameters.Select(parameter => parameter.Name).ToHashSet(StringComparer.Ordinal);
        if (!expectedNames.SetEquals(actual.Keys))
        {
            throw new InvalidOperationException($"{operation.OperationId} query keys were [{string.Join(", ", actual.Keys)}], expected [{string.Join(", ", expectedNames)}].");
        }

        foreach (var parameter in expectedParameters)
        {
            var value = actual[parameter.Name].Single();
            var hasFullPagination = expectedParameters.Any(item => item.Name == "from")
                && expectedParameters.Any(item => item.Name == "size");
            var expected = parameter.Name switch
            {
                "from" when hasFullPagination => "3",
                "size" when hasFullPagination => "2",
                _ when parameter.Enum is { Count: > 0 } => parameter.Enum[0],
                _ when parameter.Type == "boolean" => "true",
                _ when parameter.Type is "number" or "integer" => "7",
                _ when parameter.Type == "array" => "first value,second value",
                _ when operation.Path.Contains($"{{{parameter.Name}}}", StringComparison.Ordinal) => "sample value",
                _ => "sample value"
            };
            if (!string.Equals(expected, value, StringComparison.Ordinal))
            {
                throw new InvalidOperationException($"{operation.OperationId} encoded {parameter.Name}={value}, expected {expected}.");
            }
        }
    }

    private static Dictionary<string, List<string>> ParseQuery(string query)
    {
        var result = new Dictionary<string, List<string>>(StringComparer.Ordinal);
        foreach (var pair in query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var parts = pair.Split('=', 2);
            var key = Uri.UnescapeDataString(parts[0]);
            var value = Uri.UnescapeDataString(parts.Length == 2 ? parts[1] : string.Empty);
            if (!result.TryGetValue(key, out var values))
            {
                values = [];
                result.Add(key, values);
            }

            values.Add(value);
        }

        return result;
    }

    private static async Task<ApiSurfaceSnapshot> ReadSnapshotAsync()
    {
        var content = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, "multiversx-get-surface.json"));
        return JsonSerializer.Deserialize<ApiSurfaceSnapshot>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            ?? throw new InvalidOperationException("Could not deserialize the approved API surface snapshot.");
    }

    private sealed record Implementation(Type Type, MethodInfo Method, ApiOperationAttribute Attribute);

    private sealed record ApiSurfaceSnapshot(IReadOnlyList<ApiSurfaceOperation> Operations);

    private sealed record ApiSurfaceOperation(
        string Path,
        string OperationId,
        bool Deprecated,
        string DocumentationStatus,
        IReadOnlyList<ApiSurfaceParameter> Parameters);

    private sealed record ApiSurfaceParameter(
        string Name,
        string Location,
        bool Deprecated,
        string Type,
        IReadOnlyList<string>? Enum);
}
