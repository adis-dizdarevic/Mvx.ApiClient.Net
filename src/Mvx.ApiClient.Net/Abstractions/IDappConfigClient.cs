#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX DappConfig GET endpoints.</summary>
public interface IDappConfigClient
{
    /// <summary>Dapp configuration.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<DappConfig> GetDappConfigurationAsync(CancellationToken cancellationToken = default);

}
