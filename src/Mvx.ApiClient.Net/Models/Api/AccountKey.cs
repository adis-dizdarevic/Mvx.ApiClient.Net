#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountKey response returned by the MultiversX API.</summary>
public sealed class AccountKey
{
    /// <summary>Gets the upstream <c>blsKey</c> value.</summary>
    [JsonPropertyName("blsKey")]
    public string? BlsKey { get; init; }

    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>topUp</c> value.</summary>
    [JsonPropertyName("topUp")]
    public BigInteger? TopUp { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>Gets the upstream <c>rewardAddress</c> value.</summary>
    [JsonPropertyName("rewardAddress")]
    public string? RewardAddress { get; init; }

    /// <summary>Gets the upstream <c>queueIndex</c> value.</summary>
    [JsonPropertyName("queueIndex")]
    public string? QueueIndex { get; init; }

    /// <summary>Gets the upstream <c>queueSize</c> value.</summary>
    [JsonPropertyName("queueSize")]
    public string? QueueSize { get; init; }

    /// <summary>Gets the upstream <c>remainingUnBondPeriod</c> value.</summary>
    [JsonPropertyName("remainingUnBondPeriod")]
    public long? RemainingUnBondPeriod { get; init; }

}
