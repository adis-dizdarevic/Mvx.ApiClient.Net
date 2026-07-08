using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Network;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class NetworkClient : INetworkClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public NetworkClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    public async Task<StatsDto> GetStatsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<StatsDto>(EndpointPaths.NetworkStats, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<EconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<EconomicsDto>(EndpointPaths.NetworkEconomics, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<NetworkConstantsDto> GetConstantsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<NetworkConstantsDto>(EndpointPaths.NetworkConstants, new QueryOptions { Data = dataSelection }, cancellationToken);
    }

    public async Task<AboutDto> GetAboutAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<AboutDto>(EndpointPaths.NetworkAbout, new QueryOptions { Data = dataSelection }, cancellationToken);
    }
}
