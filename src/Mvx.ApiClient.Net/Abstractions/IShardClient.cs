#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Shards;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Shards GET endpoints.</summary>
public interface IShardClient
{
    /// <summary>Shards.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Shard>> GetShardsAsync(GetShardsOptions? options = null, CancellationToken cancellationToken = default);

}
