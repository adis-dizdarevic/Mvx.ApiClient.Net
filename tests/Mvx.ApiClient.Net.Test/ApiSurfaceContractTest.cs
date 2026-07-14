using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using TUnit.Assertions;

namespace Mvx.ApiClient.Net.Test;

public partial class ApiSurfaceContractTest
{
    [Test]
    public async Task ImplementedEndpointPaths_AreDocumentedAndNotDeprecatedUpstream()
    {
        var snapshotContent = await File.ReadAllTextAsync(Path.Combine(AppContext.BaseDirectory, "multiversx-get-surface.json"));
        var snapshot = JsonSerializer.Deserialize<ApiSurfaceSnapshot>(snapshotContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidOperationException("Could not deserialize the approved MultiversX API surface snapshot.");
        var operations = snapshot.Operations.ToDictionary(
            operation => NormalizePath(operation.Path),
            StringComparer.Ordinal);
        var endpointPaths = typeof(EndpointPaths)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Static)
            .Where(field => field.IsLiteral && field.FieldType == typeof(string))
            .Select(field => new
            {
                field.Name,
                Path = (string)field.GetRawConstantValue()!
            })
            .ToArray();

        foreach (var endpoint in endpointPaths)
        {
            var normalizedPath = NormalizePath($"/{endpoint.Path}");
            if (!operations.TryGetValue(normalizedPath, out var operation))
            {
                throw new InvalidOperationException($"EndpointPaths.{endpoint.Name} does not match a GET operation in the approved upstream snapshot.");
            }

            await Assert.That(operation.Deprecated).IsFalse()
                .Because($"EndpointPaths.{endpoint.Name} must not expose an upstream-deprecated GET operation");
            await Assert.That(operation.DocumentationStatus).IsNotEqualTo("excluded")
                .Because($"EndpointPaths.{endpoint.Name} must not expose an excluded GET operation");
        }
    }

    private static string NormalizePath(string path)
    {
        return PathParameterRegex().Replace(path, "{}");
    }

    [GeneratedRegex("\\{[^}]+\\}", RegexOptions.CultureInvariant)]
    private static partial Regex PathParameterRegex();

    private sealed record ApiSurfaceSnapshot(IReadOnlyList<ApiSurfaceOperation> Operations);

    private sealed record ApiSurfaceOperation(string Path, bool Deprecated, string DocumentationStatus);
}
