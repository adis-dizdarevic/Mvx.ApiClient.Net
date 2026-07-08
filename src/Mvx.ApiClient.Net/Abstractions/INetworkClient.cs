using Mvx.ApiClient.Net.Models.Network;

namespace Mvx.ApiClient.Net;

/// <summary>
/// Client for retrieving information about the current MultiversX network.
/// </summary>
public interface INetworkClient
{
    /// <summary>
    /// Returns general network statistics.
    /// </summary>
    Task<StatsDto> GetStatsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns general economics information.
    /// </summary>
    Task<EconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns network-specific constants that can be used to automatically configure dapps.
    /// </summary>
    Task<NetworkConstantsDto> GetConstantsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns general information about API deployment.
    /// </summary>
    Task<AboutDto> GetAboutAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);
}
