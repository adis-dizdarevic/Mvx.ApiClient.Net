#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Miniblocks;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Miniblocks GET endpoints.</summary>
public interface IMiniblockClient
{
    /// <summary>Miniblocks details.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<MiniBlockDetailed>> GetMiniBlocksAsync(GetMiniBlocksOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Miniblock details.</summary>
    /// <param name="miniBlockHash">The miniBlockHash value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<MiniBlockDetailed> GetMiniBlockAsync(string miniBlockHash, CancellationToken cancellationToken = default);

}
