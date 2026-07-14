#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Pool;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Pool GET endpoints.</summary>
public interface IPoolClient
{
    /// <summary>Transactions pool.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<TransactionInPool>> GetTransactionPoolAsync(GetTransactionPoolOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Transactions pool count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTransactionPoolCountAsync(GetTransactionPoolCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Transaction from pool.</summary>
    /// <param name="txhash">The txhash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<TransactionInPool> GetTransactionFromPoolAsync(string txhash, CancellationToken cancellationToken = default);

}
