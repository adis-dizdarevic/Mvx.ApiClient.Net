using Mvx.ApiClient.Dtos;
using Mvx.ApiClient.Models.Network;

namespace Mvx.ApiClient.Interfaces.Clients;

/// <summary>
/// Client for retrieving information about the current network
/// </summary>
public interface INetworkClient
{
    /// <summary>
    /// Returns general network statistics
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <returns>A <see cref="Stats"/> object containing network statistics</returns>
    Task<Stats> GetNetworkStats(DataSelectionDto? dataSelection = null);
    
    /// <summary>
    /// Returns general economics information
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <returns>An <see cref="Economics"/> object containing economics information</returns>
    Task<Economics> GetEconomics(DataSelectionDto? dataSelection = null);
    
    /// <summary>
    /// Returns network-specific constants that can be used to automatically configure dapps
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <returns>A <see cref="NetworkConstants"/> object containing network-specific constants</returns>
    Task<NetworkConstants> GetNetworkConstants(DataSelectionDto? dataSelection = null);
    
    /// <summary>
    /// Returns general information about API deployment
    /// </summary>
    /// <param name="dataSelection">The fields to retrieve from the response</param>
    /// <returns>An <see cref="About"/> object containing general information about API deployment</returns>
    Task<About> GetAbout(DataSelectionDto? dataSelection = null);
}
