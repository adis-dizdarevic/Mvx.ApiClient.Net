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
    /// <param name="dataSelection">Optional field selection or extraction settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The current network statistics.</returns>
    Task<StatsDto> GetStatsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns general economics information.
    /// </summary>
    /// <param name="dataSelection">Optional field selection or extraction settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The current network economics information.</returns>
    Task<EconomicsDto> GetEconomicsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns network-specific constants that can be used to automatically configure dapps.
    /// </summary>
    /// <param name="dataSelection">Optional field selection or extraction settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The network constants reported by the selected MultiversX API host.</returns>
    Task<NetworkConstantsDto> GetConstantsAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns general information about API deployment.
    /// </summary>
    /// <param name="dataSelection">Optional field selection or extraction settings.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>Information about the selected MultiversX API deployment.</returns>
    Task<AboutDto> GetAboutAsync(DataSelection? dataSelection = null, CancellationToken cancellationToken = default);
}
