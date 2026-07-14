#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountUsername response returned by the MultiversX API.</summary>
public sealed class AccountUsername
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>rootHash</c> value.</summary>
    [JsonPropertyName("rootHash")]
    public string? RootHash { get; init; }

    /// <summary>Gets the upstream <c>txCount</c> value.</summary>
    [JsonPropertyName("txCount")]
    public long? TxCount { get; init; }

    /// <summary>Gets the upstream <c>scrCount</c> value.</summary>
    [JsonPropertyName("scrCount")]
    public long? ScrCount { get; init; }

    /// <summary>Gets the upstream <c>username</c> value.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? Shard { get; init; }

    /// <summary>Gets the upstream <c>developerReward</c> value.</summary>
    [JsonPropertyName("developerReward")]
    public BigInteger? DeveloperReward { get; init; }

}
