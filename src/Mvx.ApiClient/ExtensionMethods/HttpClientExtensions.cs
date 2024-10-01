using Mvx.ApiClient.Dtos;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.ExtensionMethods;

internal static class HttpClientExtensions
{
    internal static async Task<T> GetWithQueryParametersAsync<T>(this HttpClient httpClient, string requestPath, QueryParametersDto? queryParameters = null)
    {
        var requestUri = BuildRequestUri(httpClient.BaseAddress!, requestPath, queryParameters);
        var response = await httpClient.GetFromJsonAsync<T>(requestUri, DefaultJsonSerializerOptions);

        if (response is null)
        {
            throw new HttpRequestException($"No response data or could not deserialize to type {typeof(T)}");
        }

        return response;
    }

    internal static Uri BuildRequestUri(Uri baseAddress, string requestPath, QueryParametersDto? queryParameters = null)
    {
        var queryDictionary = new Dictionary<string, string>();
        
        if (queryParameters?.Pagination?.Limit is not null)
        {
            queryDictionary.Add("size", queryParameters.Pagination.Limit.Value.ToString());
        }

        if (queryParameters?.Pagination?.Offset is not null)
        {
            queryDictionary.Add("from", queryParameters.Pagination.Offset.Value.ToString());
        }

        if (queryParameters?.Data?.Fields is not null && queryParameters.Data.Fields.Any())
        {
            queryDictionary.Add("fields", string.Join(",", queryParameters.Data.Fields));
        }
        
        if (!string.IsNullOrEmpty(queryParameters?.Data?.Extract))
        {
            queryDictionary.Add("extract", queryParameters.Data.Extract);
        }
        
        var queryString = string.Join("&", queryDictionary.Select(param => $"{param.Key}={param.Value}"));
        var fullUri = string.IsNullOrEmpty(queryString) ? requestPath : $"{requestPath}?{queryString}";
        var requestUri = new Uri(baseAddress, fullUri);
        
        return requestUri;
    }
    
    private static JsonSerializerOptions DefaultJsonSerializerOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };
}
