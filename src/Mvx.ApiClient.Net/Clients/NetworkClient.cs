using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.ExtensionMethods;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Network;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class NetworkClient : INetworkClient
{
    private readonly HttpClient _httpClient;

    public NetworkClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<StatsDto> GetNetworkStatsAsync(DataSelectionDto? dataSelectionDto = null, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<StatsDto>(EndpointPaths.NetworkStats, new QueryParametersDto { Data = dataSelectionDto }, cancellationToken);

        return result;
    }
    
    public async Task<EconomicsDto> GetEconomicsAsync(DataSelectionDto? dataSelectionDto = null, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<EconomicsDto>(EndpointPaths.NetworkEconomics, new QueryParametersDto { Data = dataSelectionDto }, cancellationToken);

        return result;
    }
    
    public async Task<NetworkConstantsDto> GetNetworkConstantsAsync(DataSelectionDto? dataSelectionDto = null, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<NetworkConstantsDto>(EndpointPaths.NetworkConstants, new QueryParametersDto { Data = dataSelectionDto }, cancellationToken);

        return result;
    }
    
    public async Task<AboutDto> GetAboutAsync(DataSelectionDto? dataSelectionDto = null, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.GetWithQueryParametersAsync<AboutDto>(EndpointPaths.NetworkAbout, new QueryParametersDto { Data = dataSelectionDto }, cancellationToken);

        return result;
    }
}
