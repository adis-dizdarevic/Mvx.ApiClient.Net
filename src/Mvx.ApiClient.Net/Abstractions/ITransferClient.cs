#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Transfers;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Transfers GET endpoints.</summary>
public interface ITransferClient
{
    /// <summary>Value transfers.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Transaction>> GetTransfersAsync(GetTransfersOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Account transfer count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetTransfersCountAsync(GetTransfersCountOptions? options = null, CancellationToken cancellationToken = default);

}
