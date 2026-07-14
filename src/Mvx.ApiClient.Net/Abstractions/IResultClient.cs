#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Results;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Results GET endpoints.</summary>
public interface IResultClient
{
    /// <summary>Smart contract results.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<SmartContractResult>> GetScResultsAsync(GetScResultsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Smart contracts count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetScResultsCountAsync(GetScResultsCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Smart contract results details.</summary>
    /// <param name="scHash">The scHash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<SmartContractResult> GetScResultAsync(string scHash, CancellationToken cancellationToken = default);

}
