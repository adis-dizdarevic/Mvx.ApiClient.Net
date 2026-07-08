using Mvx.ApiClient.Net.Models.Network;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class NetworkClient : INetworkClient
{
    private readonly HttpClient _httpClient;

    public NetworkClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StatsDto> GetNetworkStatsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<StatsDto>(EndpointPaths.NetworkStats, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<EconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<EconomicsDto>(EndpointPaths.NetworkEconomics, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<NetworkConstantsDto> GetNetworkConstantsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<NetworkConstantsDto>(EndpointPaths.NetworkConstants, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<AboutDto> GetAboutAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetWithQueryOptionsAsync<AboutDto>(EndpointPaths.NetworkAbout, new QueryOptions { Data = dataSelection }, cancellationToken);
    }
}
