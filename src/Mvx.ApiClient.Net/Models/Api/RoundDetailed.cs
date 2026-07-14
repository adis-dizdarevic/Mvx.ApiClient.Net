#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the RoundDetailed response returned by the MultiversX API.</summary>
public sealed class RoundDetailed
{
    /// <summary>Gets the upstream <c>blockWasProposed</c> value.</summary>
    [JsonPropertyName("blockWasProposed")]
    public bool? BlockWasProposed { get; init; }

    /// <summary>Gets the upstream <c>round</c> value.</summary>
    [JsonPropertyName("round")]
    public long? Round { get; init; }

    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? Shard { get; init; }

    /// <summary>Gets the upstream <c>epoch</c> value.</summary>
    [JsonPropertyName("epoch")]
    public long? Epoch { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

    /// <summary>Gets the upstream <c>signers</c> value.</summary>
    [JsonPropertyName("signers")]
    public IReadOnlyList<string>? Signers { get; init; }

}
