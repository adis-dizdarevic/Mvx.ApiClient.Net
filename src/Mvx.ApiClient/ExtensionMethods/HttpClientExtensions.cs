using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.ExtensionMethods;

public class HttpClientExtensions
{
    public static JsonSerializerOptions DefaultOptions { get; } = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public static async Task<T> GetWithQueryParametersAsync<T>(HttpClient httpClient, string requestUri, int? limit = null, int? offset = null, IEnumerable<string>? fields = null, string? extract = null)
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
