using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Infrastructure;

internal sealed class ApiRequestExecutor
{
    private readonly HttpClient _httpClient;

    public ApiRequestExecutor(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> GetAsync<T>(string requestPath, QueryOptions? queryOptions = null, CancellationToken cancellationToken = default)
    {
        var requestUri = BuildRequestUri(_httpClient.BaseAddress!, requestPath, QueryParameters.From(queryOptions));
        var response = await _httpClient.GetFromJsonAsync<T>(requestUri, JsonSerializerOptions, cancellationToken);

        if (response is null)
        {
            throw new HttpRequestException($"No response data or could not deserialize to type {typeof(T)}.");
        }

        return response;
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryOptions? queryOptions = null)
    {
        return BuildRequestUri(baseAddress, requestPath, QueryParameters.From(queryOptions));
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryParameters? queryParameters)
    {
        ArgumentNullException.ThrowIfNull(baseAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(requestPath);

        var queryString = queryParameters is null
            ? string.Empty
            : string.Join("&", queryParameters.Values.Select(parameter =>
                $"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}"));
        var separator = requestPath.Contains('?', StringComparison.Ordinal) ? "&" : "?";
        var fullUri = string.IsNullOrEmpty(queryString) ? requestPath : $"{requestPath}{separator}{queryString}";

        return new Uri(baseAddress, fullUri);
    }

    private static JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
}
