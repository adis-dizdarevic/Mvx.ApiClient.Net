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

    [ApiOperation("/stats", "NetworkController_getStats")]
    public async Task<StatsDto> GetStatsAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<StatsDto>(EndpointPaths.NetworkStats, null, cancellationToken);
    }

    [ApiOperation("/economics", "NetworkController_getEconomics")]
    public async Task<EconomicsDto> GetEconomicsAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<EconomicsDto>(EndpointPaths.NetworkEconomics, null, cancellationToken);
    }

    [ApiOperation("/constants", "NetworkController_getConstants")]
    public async Task<NetworkConstantsDto> GetConstantsAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<NetworkConstantsDto>(EndpointPaths.NetworkConstants, null, cancellationToken);
    }

    [ApiOperation("/about", "NetworkController_getAbout")]
    public async Task<AboutDto> GetAboutAsync(CancellationToken cancellationToken = default)
    {
        return await _requestExecutor.GetAsync<AboutDto>(EndpointPaths.NetworkAbout, null, cancellationToken);
    }
}
