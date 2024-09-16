using System.Net.Mime;
using System.Text.Json;

namespace Mvx.HttpClientProvider;

public static class HttpClientFactory
{
    private static readonly string _baseUrl = "https://api.multiversx.com";

    public static HttpClient CreateClient()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl),
        };

        httpClient.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);

        return httpClient;
    }

    public static async Task<T> GetFromJsonAsync<T>(this HttpClient httpClient, string requestUri)
    {
        var response = await httpClient.GetStringAsync(requestUri);

        var result = JsonSerializer.Deserialize<T>(response, JsonSerializerConfig.DefaultOptions);

        return result;
    }

    public static async Task<T> GetWithQueryParametersAsync<T>(this HttpClient httpClient, string requestUri, int? limit = null, int? offset = null, IEnumerable<string>? fields = null, string? extract = null)
    {
        var queryParameters = new Dictionary<string, string>();

        if (limit.HasValue)
        {
            queryParameters.Add("size", limit.Value.ToString());
        }

        if (offset.HasValue)
        {
            queryParameters.Add("from", offset.Value.ToString());
        }

        if (fields is not null && fields.Any())
        {
            queryParameters.Add("fields", string.Join(",", fields));
        }
        
        if (!string.IsNullOrEmpty(extract))
        {
            queryParameters.Add("extract", extract);
        }
        
        var queryString = string.Join("&", queryParameters.Select(param => $"{param.Key}={param.Value}"));
        var requestUrl = string.IsNullOrEmpty(queryString) ? requestUri : $"{requestUri}?{queryString}";
        
        var response = await httpClient.GetFromJsonAsync<T>(requestUrl);

        return response;
    }
}
