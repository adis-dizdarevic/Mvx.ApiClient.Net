#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the GlobalStake response returned by the MultiversX API.</summary>
public sealed class GlobalStake
{
    /// <summary>Gets the upstream <c>totalValidators</c> value.</summary>
    [JsonPropertyName("totalValidators")]
    public long? TotalValidators { get; init; }

    /// <summary>Gets the upstream <c>activeValidators</c> value.</summary>
    [JsonPropertyName("activeValidators")]
    public long? ActiveValidators { get; init; }

    /// <summary>Gets the upstream <c>totalObservers</c> value.</summary>
    [JsonPropertyName("totalObservers")]
    public long? TotalObservers { get; init; }

    /// <summary>Gets the upstream <c>queueSize</c> value.</summary>
    [JsonPropertyName("queueSize")]
    public long? QueueSize { get; init; }

    /// <summary>Gets the upstream <c>totalStaked</c> value.</summary>
    [JsonPropertyName("totalStaked")]
    public BigInteger? TotalStaked { get; init; }

    /// <summary>Gets the upstream <c>minimumAuctionQualifiedTopUp</c> value.</summary>
    [JsonPropertyName("minimumAuctionQualifiedTopUp")]
    public BigInteger? MinimumAuctionQualifiedTopUp { get; init; }

    /// <summary>Gets the upstream <c>minimumAuctionQualifiedStake</c> value.</summary>
    [JsonPropertyName("minimumAuctionQualifiedStake")]
    public BigInteger? MinimumAuctionQualifiedStake { get; init; }

    /// <summary>Gets the upstream <c>auctionValidators</c> value.</summary>
    [JsonPropertyName("auctionValidators")]
    public long? AuctionValidators { get; init; }

    /// <summary>Gets the upstream <c>nakamotoCoefficient</c> value.</summary>
    [JsonPropertyName("nakamotoCoefficient")]
    public long? NakamotoCoefficient { get; init; }

    /// <summary>Gets the upstream <c>dangerZoneValidators</c> value.</summary>
    [JsonPropertyName("dangerZoneValidators")]
    public long? DangerZoneValidators { get; init; }

    /// <summary>Gets the upstream <c>eligibleValidators</c> value.</summary>
    [JsonPropertyName("eligibleValidators")]
    public long? EligibleValidators { get; init; }

    /// <summary>Gets the upstream <c>waitingValidators</c> value.</summary>
    [JsonPropertyName("waitingValidators")]
    public long? WaitingValidators { get; init; }

    /// <summary>Gets the upstream <c>qualifiedAuctionValidators</c> value.</summary>
    [JsonPropertyName("qualifiedAuctionValidators")]
    public long? QualifiedAuctionValidators { get; init; }

    /// <summary>Gets the upstream <c>allStakedNodes</c> value.</summary>
    [JsonPropertyName("allStakedNodes")]
    public long? AllStakedNodes { get; init; }

}
