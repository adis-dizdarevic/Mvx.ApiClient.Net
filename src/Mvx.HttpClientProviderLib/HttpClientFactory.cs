using System.Net.Mime;
using System.Text.Json;

namespace Mvx.HttpClientProviderLib;

public static class HttpClientFactory
{
    private static readonly string _baseUrl = "https://api.elrond.com";

    public static HttpClient CreateClient()
    {
        var httpClient = new HttpClient()
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
}
