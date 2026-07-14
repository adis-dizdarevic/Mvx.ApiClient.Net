#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Transactions;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Transactions GET endpoints.</summary>
public interface ITransactionClient
{
    /// <summary>Transaction list.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetTransactionsAsync(GetTransactionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Transactions count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTransactionCountAsync(GetTransactionCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Transaction details.</summary>
    /// <param name="txHash">The txHash value.</param>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TransactionDetailed> GetTransactionAsync(string txHash, GetTransactionOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Price per unit by shard.</summary>
    /// <param name="shardId">The shardId value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<ProcessingUnitMetadata> GetPpuByShardIdAsync(long shardId, CancellationToken cancellationToken = default);

}
