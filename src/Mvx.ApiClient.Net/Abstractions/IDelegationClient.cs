#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Delegation GET endpoints.</summary>
public interface IDelegationClient
{
    /// <summary>Delegation statistics.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Delegation> GetDelegationDetailsAsync(CancellationToken cancellationToken = default);

    /// <summary>Legacy delegation statistics.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<DelegationLegacy> GetDelegationLegacyAsync(CancellationToken cancellationToken = default);

}
