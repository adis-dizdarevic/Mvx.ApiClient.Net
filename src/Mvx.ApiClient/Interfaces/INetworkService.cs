using Mvx.ApiClient.Models;

namespace Mvx.ApiClient.Interfaces;

internal interface INetworkService
{
    Task<Stats> GetNetworkStats();
}
