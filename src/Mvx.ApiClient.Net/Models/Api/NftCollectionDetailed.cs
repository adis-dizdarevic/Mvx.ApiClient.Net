#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftCollectionDetailed response returned by the MultiversX API.</summary>
public sealed class NftCollectionDetailed
{
    /// <summary>Gets the upstream <c>collection</c> value.</summary>
    [JsonPropertyName("collection")]
    public string? Collection { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public NftCollectionDetailedType? Type { get; init; }

    /// <summary>Gets the upstream <c>subType</c> value.</summary>
    [JsonPropertyName("subType")]
    public NftCollectionDetailedSubType? SubType { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>ticker</c> value.</summary>
    [JsonPropertyName("ticker")]
    public string? Ticker { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>timestampMs</c> value.</summary>
    [JsonPropertyName("timestampMs")]
    public long? TimestampMs { get; init; }

    /// <summary>Gets the upstream <c>canFreeze</c> value.</summary>
    [JsonPropertyName("canFreeze")]
    public bool? CanFreeze { get; init; }

    /// <summary>Gets the upstream <c>canWipe</c> value.</summary>
    [JsonPropertyName("canWipe")]
    public bool? CanWipe { get; init; }

    /// <summary>Gets the upstream <c>canPause</c> value.</summary>
    [JsonPropertyName("canPause")]
    public bool? CanPause { get; init; }

    /// <summary>Gets the upstream <c>canTransferNftCreateRole</c> value.</summary>
    [JsonPropertyName("canTransferNftCreateRole")]
    public bool? CanTransferNftCreateRole { get; init; }

    /// <summary>Gets the upstream <c>canChangeOwner</c> value.</summary>
    [JsonPropertyName("canChangeOwner")]
    public bool? CanChangeOwner { get; init; }

    /// <summary>Gets the upstream <c>canUpgrade</c> value.</summary>
    [JsonPropertyName("canUpgrade")]
    public bool? CanUpgrade { get; init; }

    /// <summary>Gets the upstream <c>canAddSpecialRoles</c> value.</summary>
    [JsonPropertyName("canAddSpecialRoles")]
    public bool? CanAddSpecialRoles { get; init; }

    /// <summary>Gets the upstream <c>decimals</c> value.</summary>
    [JsonPropertyName("decimals")]
    public long? Decimals { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public TokenAssets? Assets { get; init; }

    /// <summary>Gets the upstream <c>scamInfo</c> value.</summary>
    [JsonPropertyName("scamInfo")]
    public ScamInfo? ScamInfo { get; init; }

    /// <summary>Gets the upstream <c>traits</c> value.</summary>
    [JsonPropertyName("traits")]
    public IReadOnlyList<CollectionTrait>? Traits { get; init; }

    /// <summary>Gets the upstream <c>auctionStats</c> value.</summary>
    [JsonPropertyName("auctionStats")]
    public CollectionAuctionStats? AuctionStats { get; init; }

    /// <summary>Gets the upstream <c>isVerified</c> value.</summary>
    [JsonPropertyName("isVerified")]
    public bool? IsVerified { get; init; }

    /// <summary>Gets the upstream <c>holderCount</c> value.</summary>
    [JsonPropertyName("holderCount")]
    public long? HolderCount { get; init; }

    /// <summary>Gets the upstream <c>nftCount</c> value.</summary>
    [JsonPropertyName("nftCount")]
    public long? NftCount { get; init; }

    /// <summary>Gets the upstream <c>canTransfer</c> value.</summary>
    [JsonPropertyName("canTransfer")]
    public bool? CanTransfer { get; init; }

    /// <summary>Gets the upstream <c>roles</c> value.</summary>
    [JsonPropertyName("roles")]
    public IReadOnlyList<CollectionRoles>? Roles { get; init; }

}
