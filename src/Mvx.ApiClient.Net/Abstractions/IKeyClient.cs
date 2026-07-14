#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Keys GET endpoints.</summary>
public interface IKeyClient
{
    /// <summary>Unbonding period.</summary>
    /// <param name="key">The key value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<KeyUnbondPeriod> GetKeyUnbondPeriodAsync(string key, CancellationToken cancellationToken = default);

}
