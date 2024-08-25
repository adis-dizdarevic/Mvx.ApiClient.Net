using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Models;
using Mvx.HttpClientProviderLib;
using System.Net.Http.Json;

namespace Mvx.ApiClient.Services;

internal class NetworkService : INetworkService
{
    private readonly HttpClient _httpClient;

    public NetworkService(HttpClient httpClient)
    {
        _httpClient = HttpClientFactory.CreateClient();
    }

    public async Task<Stats> GetNetworkStats()
    {
        var requestUri = "/stats";

        var response = await _httpClient.GetFromJsonAsync<Stats>(requestUri, JsonSerializerConfig.DefaultOptions);

        return response;
    }
}
