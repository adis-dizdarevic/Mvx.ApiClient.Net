#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Node response returned by the MultiversX API.</summary>
public sealed class Node
{
    /// <summary>Gets the upstream <c>bls</c> value.</summary>
    [JsonPropertyName("bls")]
    public string? Bls { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>version</c> value.</summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>Gets the upstream <c>rating</c> value.</summary>
    [JsonPropertyName("rating")]
    public long? Rating { get; init; }

    /// <summary>Gets the upstream <c>tempRating</c> value.</summary>
    [JsonPropertyName("tempRating")]
    public long? TempRating { get; init; }

    /// <summary>Gets the upstream <c>ratingModifier</c> value.</summary>
    [JsonPropertyName("ratingModifier")]
    public decimal? RatingModifier { get; init; }

    /// <summary>Gets the upstream <c>shard</c> value.</summary>
    [JsonPropertyName("shard")]
    public long? Shard { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public NodeType? Type { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public NodeStatus? Status { get; init; }

    /// <summary>Gets the upstream <c>online</c> value.</summary>
    [JsonPropertyName("online")]
    public bool? Online { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>instances</c> value.</summary>
    [JsonPropertyName("instances")]
    public long? Instances { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>identity</c> value.</summary>
    [JsonPropertyName("identity")]
    public string? Identity { get; init; }

    /// <summary>Gets the upstream <c>provider</c> value.</summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>Gets the upstream <c>issues</c> value.</summary>
    [JsonPropertyName("issues")]
    public IReadOnlyList<string>? Issues { get; init; }

    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>topUp</c> value.</summary>
    [JsonPropertyName("topUp")]
    public BigInteger? TopUp { get; init; }

    /// <summary>Gets the upstream <c>locked</c> value.</summary>
    [JsonPropertyName("locked")]
    public BigInteger? Locked { get; init; }

    /// <summary>Gets the upstream <c>leaderFailure</c> value.</summary>
    [JsonPropertyName("leaderFailure")]
    public long? LeaderFailure { get; init; }

    /// <summary>Gets the upstream <c>leaderSuccess</c> value.</summary>
    [JsonPropertyName("leaderSuccess")]
    public long? LeaderSuccess { get; init; }

    /// <summary>Gets the upstream <c>validatorFailure</c> value.</summary>
    [JsonPropertyName("validatorFailure")]
    public long? ValidatorFailure { get; init; }

    /// <summary>Gets the upstream <c>validatorIgnoredSignatures</c> value.</summary>
    [JsonPropertyName("validatorIgnoredSignatures")]
    public long? ValidatorIgnoredSignatures { get; init; }

    /// <summary>Gets the upstream <c>validatorSuccess</c> value.</summary>
    [JsonPropertyName("validatorSuccess")]
    public long? ValidatorSuccess { get; init; }

    /// <summary>Gets the upstream <c>position</c> value.</summary>
    [JsonPropertyName("position")]
    public long? Position { get; init; }

    /// <summary>Gets the upstream <c>auctioned</c> value.</summary>
    [JsonPropertyName("auctioned")]
    public bool? Auctioned { get; init; }

    /// <summary>Gets the upstream <c>auctionPosition</c> value.</summary>
    [JsonPropertyName("auctionPosition")]
    public long? AuctionPosition { get; init; }

    /// <summary>Gets the upstream <c>auctionTopUp</c> value.</summary>
    [JsonPropertyName("auctionTopUp")]
    public BigInteger? AuctionTopUp { get; init; }

    /// <summary>Gets the upstream <c>auctionQualified</c> value.</summary>
    [JsonPropertyName("auctionQualified")]
    public bool? AuctionQualified { get; init; }

    /// <summary>Gets the upstream <c>fullHistory</c> value.</summary>
    [JsonPropertyName("fullHistory")]
    public bool? FullHistory { get; init; }

    /// <summary>Gets the upstream <c>syncProgress</c> value.</summary>
    [JsonPropertyName("syncProgress")]
    public decimal? SyncProgress { get; init; }

    /// <summary>Gets the upstream <c>remainingUnBondPeriod</c> value.</summary>
    [JsonPropertyName("remainingUnBondPeriod")]
    public long? RemainingUnBondPeriod { get; init; }

    /// <summary>Gets the upstream <c>isInDangerZone</c> value.</summary>
    [JsonPropertyName("isInDangerZone")]
    public bool? IsInDangerZone { get; init; }

    /// <summary>Gets the upstream <c>epochsLeft</c> value.</summary>
    [JsonPropertyName("epochsLeft")]
    public long? EpochsLeft { get; init; }

    /// <summary>Gets the upstream <c>identityInfo</c> value.</summary>
    [JsonPropertyName("identityInfo")]
    public Identity? IdentityInfo { get; init; }

    /// <summary>Gets the upstream <c>qualifiedStake</c> value.</summary>
    [JsonPropertyName("qualifiedStake")]
    public BigInteger? QualifiedStake { get; init; }

}
