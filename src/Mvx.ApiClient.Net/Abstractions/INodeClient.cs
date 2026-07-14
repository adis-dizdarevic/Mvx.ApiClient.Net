#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Nodes;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Nodes GET endpoints.</summary>
public interface INodeClient
{
    /// <summary>Nodes.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Node>> GetNodesAsync(GetNodesOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Node versions.</summary>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyDictionary<string, decimal>> GetNodeVersionsAsync(CancellationToken cancellationToken = default);

    /// <summary>Nodes count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetNodeCountAsync(GetNodeCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Nodes Auctions.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<NodeAuction>> GetNodesAuctionsAsync(GetNodesAuctionsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Node.</summary>
    /// <param name="bls">The bls value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<Node> GetNodeAsync(string bls, CancellationToken cancellationToken = default);

}
