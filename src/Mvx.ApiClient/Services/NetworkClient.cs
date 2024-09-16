using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Interfaces.Clients;
using Mvx.ApiClient.Models;
using Mvx.ApiClient.Models.Network;
using Mvx.HttpClientProvider;

namespace Mvx.ApiClient.Services;

public class NetworkClient : INetworkClient
{
    private readonly HttpClient _httpClient;

    public NetworkClient()
    {
        _httpClient = HttpClientFactory.CreateClient();
    }

    public async Task<Stats> GetNetworkStats()
    {
        var requestUri = "/stats";

        var response = await _httpClient.GetWithQueryParametersAsync<Stats>(requestUri);

        return response; 
    }
    
    public Task<Economics> GetEconomics()
    {
        throw new NotImplementedException();
    }
    
    public Task<NetworkConstants> GetNetworkConstants()
    {
        throw new NotImplementedException();
    }
    
    public Task<About> GetAbout()
    {
        throw new NotImplementedException();
    }
}
