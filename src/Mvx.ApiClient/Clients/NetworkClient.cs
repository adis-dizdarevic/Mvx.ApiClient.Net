using Mvx.ApiClient.Interfaces.Clients;
using Mvx.ApiClient.Models.Network;
using System.Net.Http.Json;

namespace Mvx.ApiClient.Clients;

public class NetworkClient : INetworkClient
{
    private readonly HttpClient _httpClient;

    public NetworkClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Stats> GetNetworkStats()
    {
        const string requestUri = "/stats";

        var result = await _httpClient.GetFromJsonAsync<Stats>(requestUri);

        return result!;
    }
    
    public async Task<Economics> GetEconomics()
    {
        const string requestUri = "/economics";

        var result = await _httpClient.GetFromJsonAsync<Economics>(requestUri);

        return result!;
    }
    
    public async Task<NetworkConstants> GetNetworkConstants()
    {
        const string requestUri = "/constants";
        
        var result = await _httpClient.GetFromJsonAsync<NetworkConstants>(requestUri);

        return result!;
    }
    
    public async Task<About> GetAbout()
    {
        const string requestUri = "/about";
        
        var result = await _httpClient.GetFromJsonAsync<About>(requestUri);

        return result!;
    }
}
