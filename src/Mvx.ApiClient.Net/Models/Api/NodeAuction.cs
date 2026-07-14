#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NodeAuction response returned by the MultiversX API.</summary>
public sealed class NodeAuction
{
    /// <summary>Gets the upstream <c>identity</c> value.</summary>
    [JsonPropertyName("identity")]
    public string? Identity { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>avatar</c> value.</summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>Gets the upstream <c>provider</c> value.</summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; init; }

    /// <summary>Gets the upstream <c>bls</c> value.</summary>
    [JsonPropertyName("bls")]
    public string? Bls { get; init; }

    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>distribution</c> value.</summary>
    [JsonPropertyName("distribution")]
    public IReadOnlyDictionary<string, decimal>? Distribution { get; init; }

    /// <summary>Gets the upstream <c>auctionTopUp</c> value.</summary>
    [JsonPropertyName("auctionTopUp")]
    public BigInteger? AuctionTopUp { get; init; }

    /// <summary>Gets the upstream <c>qualifiedStake</c> value.</summary>
    [JsonPropertyName("qualifiedStake")]
    public BigInteger? QualifiedStake { get; init; }

    /// <summary>Gets the upstream <c>auctionValidators</c> value.</summary>
    [JsonPropertyName("auctionValidators")]
    public long? AuctionValidators { get; init; }

    /// <summary>Gets the upstream <c>qualifiedAuctionValidators</c> value.</summary>
    [JsonPropertyName("qualifiedAuctionValidators")]
    public long? QualifiedAuctionValidators { get; init; }

    /// <summary>Gets the upstream <c>droppedValidators</c> value.</summary>
    [JsonPropertyName("droppedValidators")]
    public long? DroppedValidators { get; init; }

    /// <summary>Gets the upstream <c>dangerZoneValidators</c> value.</summary>
    [JsonPropertyName("dangerZoneValidators")]
    public long? DangerZoneValidators { get; init; }

}
