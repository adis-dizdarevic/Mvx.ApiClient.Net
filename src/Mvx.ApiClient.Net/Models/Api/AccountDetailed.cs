#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountDetailed response returned by the MultiversX API.</summary>
public sealed class AccountDetailed
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

    /// <summary>Gets the upstream <c>code</c> value.</summary>
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>Gets the upstream <c>codeHash</c> value.</summary>
    [JsonPropertyName("codeHash")]
    public string? CodeHash { get; init; }

    /// <summary>Gets the upstream <c>rootHash</c> value.</summary>
    [JsonPropertyName("rootHash")]
    public string? RootHash { get; init; }

    /// <summary>Gets the upstream <c>username</c> value.</summary>
    [JsonPropertyName("username")]
    public JsonElement? Username { get; init; }

    /// <summary>Gets the upstream <c>developerReward</c> value.</summary>
    [JsonPropertyName("developerReward")]
    public BigInteger? DeveloperReward { get; init; }

    /// <summary>Gets the upstream <c>isUpgradeable</c> value.</summary>
    [JsonPropertyName("isUpgradeable")]
    public bool? IsUpgradeable { get; init; }

    /// <summary>Gets the upstream <c>isReadable</c> value.</summary>
    [JsonPropertyName("isReadable")]
    public bool? IsReadable { get; init; }

    /// <summary>Gets the upstream <c>isPayable</c> value.</summary>
    [JsonPropertyName("isPayable")]
    public bool? IsPayable { get; init; }

    /// <summary>Gets the upstream <c>isPayableBySmartContract</c> value.</summary>
    [JsonPropertyName("isPayableBySmartContract")]
    public bool? IsPayableBySmartContract { get; init; }

    /// <summary>Gets the upstream <c>scamInfo</c> value.</summary>
    [JsonPropertyName("scamInfo")]
    public ScamInfo? ScamInfo { get; init; }

    /// <summary>Gets the upstream <c>nftCollections</c> value.</summary>
    [JsonPropertyName("nftCollections")]
    public bool? NftCollections { get; init; }

    /// <summary>Gets the upstream <c>nfts</c> value.</summary>
    [JsonPropertyName("nfts")]
    public bool? Nfts { get; init; }

    /// <summary>Gets the upstream <c>activeGuardianActivationEpoch</c> value.</summary>
    [JsonPropertyName("activeGuardianActivationEpoch")]
    public long? ActiveGuardianActivationEpoch { get; init; }

    /// <summary>Gets the upstream <c>activeGuardianAddress</c> value.</summary>
    [JsonPropertyName("activeGuardianAddress")]
    public string? ActiveGuardianAddress { get; init; }

    /// <summary>Gets the upstream <c>activeGuardianServiceUid</c> value.</summary>
    [JsonPropertyName("activeGuardianServiceUid")]
    public string? ActiveGuardianServiceUid { get; init; }

    /// <summary>Gets the upstream <c>pendingGuardianActivationEpoch</c> value.</summary>
    [JsonPropertyName("pendingGuardianActivationEpoch")]
    public long? PendingGuardianActivationEpoch { get; init; }

    /// <summary>Gets the upstream <c>pendingGuardianAddress</c> value.</summary>
    [JsonPropertyName("pendingGuardianAddress")]
    public string? PendingGuardianAddress { get; init; }

    /// <summary>Gets the upstream <c>pendingGuardianServiceUid</c> value.</summary>
    [JsonPropertyName("pendingGuardianServiceUid")]
    public string? PendingGuardianServiceUid { get; init; }

    /// <summary>Gets the upstream <c>isGuarded</c> value.</summary>
    [JsonPropertyName("isGuarded")]
    public bool? IsGuarded { get; init; }

}
