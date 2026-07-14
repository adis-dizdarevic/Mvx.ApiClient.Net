#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Stake GET endpoints.</summary>
public interface IStakeClient
{
    /// <summary>Stake.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<GlobalStake> GetGlobalStakeAsync(CancellationToken cancellationToken = default);

}
