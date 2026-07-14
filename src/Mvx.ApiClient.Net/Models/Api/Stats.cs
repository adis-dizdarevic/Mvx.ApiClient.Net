#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Stats response returned by the MultiversX API.</summary>
public sealed class Stats
{
    /// <summary>Gets the upstream <c>accounts</c> value.</summary>
    [JsonPropertyName("accounts")]
    public long? Accounts { get; init; }

    /// <summary>Gets the upstream <c>blocks</c> value.</summary>
    [JsonPropertyName("blocks")]
    public long? Blocks { get; init; }

    /// <summary>Gets the upstream <c>epoch</c> value.</summary>
    [JsonPropertyName("epoch")]
    public long? Epoch { get; init; }

    /// <summary>Gets the upstream <c>refreshRate</c> value.</summary>
    [JsonPropertyName("refreshRate")]
    public long? RefreshRate { get; init; }

    /// <summary>Gets the upstream <c>roundsPassed</c> value.</summary>
    [JsonPropertyName("roundsPassed")]
    public long? RoundsPassed { get; init; }

    /// <summary>Gets the upstream <c>roundsPerEpoch</c> value.</summary>
    [JsonPropertyName("roundsPerEpoch")]
    public long? RoundsPerEpoch { get; init; }

    /// <summary>Gets the upstream <c>shards</c> value.</summary>
    [JsonPropertyName("shards")]
    public long? Shards { get; init; }

    /// <summary>Gets the upstream <c>transactions</c> value.</summary>
    [JsonPropertyName("transactions")]
    public long? Transactions { get; init; }

    /// <summary>Gets the upstream <c>scResults</c> value.</summary>
    [JsonPropertyName("scResults")]
    public long? ScResults { get; init; }

}
