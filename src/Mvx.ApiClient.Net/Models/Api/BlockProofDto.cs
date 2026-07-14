#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the BlockProofDto response returned by the MultiversX API.</summary>
public sealed class BlockProofDto
{
    /// <summary>Gets the upstream <c>pubKeysBitmap</c> value.</summary>
    [JsonPropertyName("pubKeysBitmap")]
    public string? PubKeysBitmap { get; init; }

    /// <summary>Gets the upstream <c>aggregatedSignature</c> value.</summary>
    [JsonPropertyName("aggregatedSignature")]
    public string? AggregatedSignature { get; init; }

    /// <summary>Gets the upstream <c>headerHash</c> value.</summary>
    [JsonPropertyName("headerHash")]
    public string? HeaderHash { get; init; }

    /// <summary>Gets the upstream <c>headerEpoch</c> value.</summary>
    [JsonPropertyName("headerEpoch")]
    public long? HeaderEpoch { get; init; }

    /// <summary>Gets the upstream <c>headerNonce</c> value.</summary>
    [JsonPropertyName("headerNonce")]
    public long? HeaderNonce { get; init; }

    /// <summary>Gets the upstream <c>headerRound</c> value.</summary>
    [JsonPropertyName("headerRound")]
    public long? HeaderRound { get; init; }

}
