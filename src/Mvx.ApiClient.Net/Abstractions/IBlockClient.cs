#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Blocks;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Blocks GET endpoints.</summary>
public interface IBlockClient
{
    /// <summary>Blocks.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Block>> GetBlocksAsync(GetBlocksOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Blocks count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetBlocksCountAsync(GetBlocksCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Block details.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<BlockDetailed> GetLatestBlockAsync(GetLatestBlockOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Block details.</summary>
    /// <param name="hash">The hash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<BlockDetailed> GetBlockAsync(string hash, CancellationToken cancellationToken = default);

}
