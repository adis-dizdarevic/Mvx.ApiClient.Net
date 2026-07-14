#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the BlockDetailed response returned by the MultiversX API.</summary>
public sealed class BlockDetailed
{
    /// <summary>Gets the upstream <c>hash</c> value.</summary>
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>Gets the upstream <c>epoch</c> value.</summary>
    [JsonPropertyName("epoch")]
    public long? Epoch { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>prevHash</c> value.</summary>
    [JsonPropertyName("prevHash")]
    public string? PrevHash { get; init; }

    /// <summary>Gets the upstream <c>proposer</c> value.</summary>
    [JsonPropertyName("proposer")]
    public string? Proposer { get; init; }

    /// <summary>Gets the upstream <c>proposerIdentity</c> value.</summary>
    [JsonPropertyName("proposerIdentity")]
    public Identity? ProposerIdentity { get; init; }

    /// <summary>Gets the upstream <c>pubKeyBitmap</c> value.</summary>
    [JsonPropertyName("pubKeyBitmap")]
    public string? PubKeyBitmap { get; init; }

    /// <summary>Gets the upstream <c>round</c> value.</summary>
    [JsonPropertyName("round")]
    public long? Round { get; init; }

    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? Shard { get; init; }

    /// <summary>Gets the upstream <c>size</c> value.</summary>
    [JsonPropertyName("size")]
    public long? Size { get; init; }

    /// <summary>Gets the upstream <c>sizeTxs</c> value.</summary>
    [JsonPropertyName("sizeTxs")]
    public long? SizeTxs { get; init; }

    /// <summary>Gets the upstream <c>stateRootHash</c> value.</summary>
    [JsonPropertyName("stateRootHash")]
    public string? StateRootHash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

    /// <summary>Gets the upstream <c>txCount</c> value.</summary>
    [JsonPropertyName("txCount")]
    public long? TxCount { get; init; }

    /// <summary>Gets the upstream <c>gasConsumed</c> value.</summary>
    [JsonPropertyName("gasConsumed")]
    public long? GasConsumed { get; init; }

    /// <summary>Gets the upstream <c>gasRefunded</c> value.</summary>
    [JsonPropertyName("gasRefunded")]
    public long? GasRefunded { get; init; }

    /// <summary>Gets the upstream <c>gasPenalized</c> value.</summary>
    [JsonPropertyName("gasPenalized")]
    public long? GasPenalized { get; init; }

    /// <summary>Gets the upstream <c>maxGasLimit</c> value.</summary>
    [JsonPropertyName("maxGasLimit")]
    public long? MaxGasLimit { get; init; }

    /// <summary>Gets the upstream <c>scheduledRootHash</c> value.</summary>
    [JsonPropertyName("scheduledRootHash")]
    public string? ScheduledRootHash { get; init; }

    /// <summary>Gets the upstream <c>previousHeaderProof</c> value.</summary>
    [JsonPropertyName("previousHeaderProof")]
    public BlockProofDto? PreviousHeaderProof { get; init; }

    /// <summary>Gets the upstream <c>reserved</c> value.</summary>
    [JsonPropertyName("reserved")]
    public string? Reserved { get; init; }

    /// <summary>Gets the upstream <c>lastExecutionResultHash</c> value.</summary>
    [JsonPropertyName("lastExecutionResultHash")]
    public string? LastExecutionResultHash { get; init; }

    /// <summary>Gets the upstream <c>lastExecutionResultNonce</c> value.</summary>
    [JsonPropertyName("lastExecutionResultNonce")]
    public long? LastExecutionResultNonce { get; init; }

    /// <summary>Gets the upstream <c>proof</c> value.</summary>
    [JsonPropertyName("proof")]
    public BlockProofDto? Proof { get; init; }

    /// <summary>Gets the upstream <c>miniBlocksHashes</c> value.</summary>
    [JsonPropertyName("miniBlocksHashes")]
    public IReadOnlyList<string>? MiniBlocksHashes { get; init; }

    /// <summary>Gets the upstream <c>notarizedBlocksHashes</c> value.</summary>
    [JsonPropertyName("notarizedBlocksHashes")]
    public IReadOnlyList<string>? NotarizedBlocksHashes { get; init; }

    /// <summary>Gets the upstream <c>validators</c> value.</summary>
    [JsonPropertyName("validators")]
    public IReadOnlyList<string>? Validators { get; init; }

}
