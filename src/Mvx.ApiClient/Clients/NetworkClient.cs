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
        const string requestPath = "/stats";

        var result = await _httpClient.GetWithQueryParametersAsync<Stats>(requestPath, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<Economics> GetEconomics(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestPath = "/economics";

        var result = await _httpClient.GetWithQueryParametersAsync<Economics>(requestPath, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<NetworkConstants> GetNetworkConstants(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestPath = "/constants";
        
        var result = await _httpClient.GetWithQueryParametersAsync<NetworkConstants>(requestPath, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
    
    /// <inheritdoc/>
    public async Task<About> GetAbout(DataSelectionDto? dataSelectionDto = null)
    {
        const string requestPath = "/about";
        
        var result = await _httpClient.GetWithQueryParametersAsync<About>(requestPath, new QueryParametersDto { Data = dataSelectionDto });

        return result;
    }
}
