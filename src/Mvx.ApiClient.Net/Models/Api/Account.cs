#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Account response returned by the MultiversX API.</summary>
public sealed class Account
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? Shard { get; init; }

    /// <summary>Gets the upstream <c>ownerAddress</c> value.</summary>
    [JsonPropertyName("ownerAddress")]
    public string? OwnerAddress { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public AccountAssets? Assets { get; init; }

    /// <summary>Gets the upstream <c>deployedAt</c> value.</summary>
    [JsonPropertyName("deployedAt")]
    public long? DeployedAt { get; init; }

    /// <summary>Gets the upstream <c>deployTxHash</c> value.</summary>
    [JsonPropertyName("deployTxHash")]
    public JsonElement? DeployTxHash { get; init; }

    /// <summary>Gets the upstream <c>ownerAssets</c> value.</summary>
    [JsonPropertyName("ownerAssets")]
    public AccountAssets? OwnerAssets { get; init; }

    /// <summary>Gets the upstream <c>isVerified</c> value.</summary>
    [JsonPropertyName("isVerified")]
    public bool? IsVerified { get; init; }

    /// <summary>Gets the upstream <c>txCount</c> value.</summary>
    [JsonPropertyName("txCount")]
    public long? TxCount { get; init; }

    /// <summary>Gets the upstream <c>scrCount</c> value.</summary>
    [JsonPropertyName("scrCount")]
    public long? ScrCount { get; init; }

    /// <summary>Gets the upstream <c>transfersLast24h</c> value.</summary>
    [JsonPropertyName("transfersLast24h")]
    public long? TransfersLast24H { get; init; }

}
