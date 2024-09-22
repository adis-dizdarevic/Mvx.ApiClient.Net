using Mvx.ApiClient.Dtos;
using Mvx.ApiClient.ExtensionMethods;
using Mvx.ApiClient.Interfaces.Clients;
using Mvx.ApiClient.Models.Network;

namespace Mvx.ApiClient.Clients;

public class NetworkClient : INetworkClient
{
    private readonly HttpClient _httpClient;

    public NetworkClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc/>
    public async Task<Stats> GetNetworkStats(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestUri = "/stats";

        var result = await _httpClient.GetWithQueryParametersAsync<Stats>(requestUri, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<Economics> GetEconomics(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestUri = "/economics";

        var result = await _httpClient.GetWithQueryParametersAsync<Economics>(requestUri, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<NetworkConstants> GetNetworkConstants(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestUri = "/constants";
        
        var result = await _httpClient.GetWithQueryParametersAsync<NetworkConstants>(requestUri, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<About> GetAbout(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestUri = "/about";
        
        var result = await _httpClient.GetWithQueryParametersAsync<About>(requestUri, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
}
