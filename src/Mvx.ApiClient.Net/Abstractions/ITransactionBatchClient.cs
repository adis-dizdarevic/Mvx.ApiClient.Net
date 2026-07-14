#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX TransactionBatches GET endpoints.</summary>
public interface ITransactionBatchClient
{
    /// <summary>Gets data from the MultiversX API..</summary>
    /// <param name="address">The address value.</param>
    /// <param name="id">The id value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TransactionBatchResult> GetTransactionBatchAsync(string address, string id, CancellationToken cancellationToken = default);

    /// <summary>Gets data from the MultiversX API..</summary>
    /// <param name="address">The address value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TransactionBatchResult>> GetTransactionBatchesAsync(string address, CancellationToken cancellationToken = default);

}
