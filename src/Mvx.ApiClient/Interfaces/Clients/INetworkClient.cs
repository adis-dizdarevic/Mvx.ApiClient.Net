using Mvx.ApiClient.Models.Network;

namespace Mvx.ApiClient.Interfaces.Clients;

public interface INetworkClient
{
    /// <summary>
    /// Returns general network statistics
    /// </summary>
    /// <param name="limit">The number of items to retrieve</param>
    /// <param name="offset">The number of items to skip</param>
    /// <param name="fields">The specific fields to retrieve</param>
    /// <param name="extract">The scalar value to extract</param>
    /// <returns></returns>
    Task<Stats> GetNetworkStats();
    
    /// <summary>
    /// Returns general economics information
    /// </summary>
    /// <returns></returns>
    Task<Economics> GetEconomics();
    
    /// <summary>
    /// Returns network-specific constants that can be used to automatically configure dapps
    /// </summary>
    /// <returns></returns>
    Task<NetworkConstants> GetNetworkConstants();
    
    /// <summary>
    /// Returns general information about API deployment
    /// </summary>
    /// <returns></returns>
    Task<About> GetAbout();
}
