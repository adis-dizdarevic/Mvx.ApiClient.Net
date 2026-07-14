#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Rounds;

namespace Mvx.ApiClient.Net;

/// <summary>Client for MultiversX Rounds GET endpoints.</summary>
public interface IRoundClient
{
    /// <summary>Rounds.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<IReadOnlyList<Round>> GetRoundsAsync(GetRoundsOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Rounds count.</summary>
    /// <param name="options">The options value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<long> GetRoundCountAsync(GetRoundCountOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Round.</summary>
    /// <param name="shard">The shard value.</param>
    /// <param name="round">The round value.</param>
    /// <param name="cancellationToken">A token that can cancel the request.</param>
    /// <returns>The response returned by the MultiversX API.</returns>
    Task<RoundDetailed> GetRoundAsync(long shard, long round, CancellationToken cancellationToken = default);

}
