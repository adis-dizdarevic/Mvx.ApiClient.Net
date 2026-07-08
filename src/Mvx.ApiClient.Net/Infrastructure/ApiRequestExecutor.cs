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
        var requestUri = BuildRequestUri(_httpClient.BaseAddress!, requestPath, queryOptions);
        var response = await _httpClient.GetFromJsonAsync<T>(requestUri, JsonSerializerOptions, cancellationToken);

        if (response is null)
        {
            throw new HttpRequestException($"No response data or could not deserialize to type {typeof(T)}.");
        }

        return response;
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryOptions? queryOptions = null)
    {
        Validate(queryOptions);

        var queryDictionary = new Dictionary<string, string>();

        if (queryOptions?.Pagination?.Limit is not null)
        {
            queryDictionary.Add("size", queryOptions.Pagination.Limit.Value.ToString());
        }

        if (queryOptions?.Pagination?.Offset is not null)
        {
            queryDictionary.Add("from", queryOptions.Pagination.Offset.Value.ToString());
        }

        if (queryOptions?.Data?.Fields is not null && queryOptions.Data.Fields.Any())
        {
            queryDictionary.Add("fields", string.Join(",", queryOptions.Data.Fields));
        }

        if (!string.IsNullOrWhiteSpace(queryOptions?.Data?.Extract))
        {
            queryDictionary.Add("extract", queryOptions.Data.Extract);
        }

        var queryString = string.Join("&", queryDictionary.Select(param => $"{param.Key}={Uri.EscapeDataString(param.Value)}"));
        var fullUri = string.IsNullOrEmpty(queryString) ? requestPath : $"{requestPath}?{queryString}";

        return new Uri(baseAddress, fullUri);
    }

    private static void Validate(QueryOptions? queryOptions)
    {
        if (queryOptions?.Pagination?.Limit < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(queryOptions), "Pagination limit cannot be negative.");
        }

        if (queryOptions?.Pagination?.Offset < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(queryOptions), "Pagination offset cannot be negative.");
        }

        if (queryOptions?.Data?.Fields?.Any(string.IsNullOrWhiteSpace) is true)
        {
            throw new ArgumentException("Field names cannot be empty.", nameof(queryOptions));
        }
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
