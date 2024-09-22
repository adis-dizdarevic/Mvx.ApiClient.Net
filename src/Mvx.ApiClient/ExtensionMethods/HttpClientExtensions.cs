using Mvx.ApiClient.Dtos;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.ExtensionMethods;

internal static class HttpClientExtensions
{
    internal static async Task<T> GetWithQueryParametersAsync<T>(this HttpClient httpClient, string requestUri, QueryParametersDto? queryParameters = null)
    {
        requestUri = BuildRequestUri(requestUri, queryParameters);
        var response = await httpClient.GetFromJsonAsync<T>(requestUri, DefaultJsonSerializerOptions);

        return response;
    }

    internal static string BuildRequestUri(string requestUri, QueryParametersDto? queryParameters = null)
    {
        var queryDictionary = new Dictionary<string, string>();
        
        if (queryParameters?.Pagination is { Limit: not null })
        {
            queryDictionary.Add("size", queryParameters.Pagination.Limit.Value.ToString());
        }

        if (queryParameters?.Pagination is { Offset: not null })
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
        requestUri = string.IsNullOrEmpty(queryString) ? requestUri : $"{requestUri}?{queryString}";

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
