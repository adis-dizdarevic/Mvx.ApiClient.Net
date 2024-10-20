using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Models.Network;

namespace Mvx.ApiClient.Net.Interfaces.Clients;

/// <summary>
/// Client for retrieving information about the current network
/// </summary>
public interface INetworkClient
{
    /// <summary>
    /// Returns general network statistics
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="StatsDto"/> object containing network statistics</returns>
    Task<StatsDto> GetNetworkStatsAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns general economics information
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>An <see cref="EconomicsDto"/> object containing economics information</returns>
    Task<EconomicsDto> GetEconomicsAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns network-specific constants that can be used to automatically configure dapps
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="NetworkConstantsDto"/> object containing network-specific constants</returns>
    Task<NetworkConstantsDto> GetNetworkConstantsAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns general information about API deployment
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>An <see cref="AboutDto"/> object containing general information about API deployment</returns>
    Task<AboutDto> GetAboutAsync(DataSelectionDto? dataSelection = null, CancellationToken cancellationToken = default);
}
