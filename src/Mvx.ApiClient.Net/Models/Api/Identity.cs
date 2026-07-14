#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Identity response returned by the MultiversX API.</summary>
public sealed class Identity
{
    /// <summary>Gets the upstream <c>identity</c> value.</summary>
    [JsonPropertyName("identity")]
    public string? IdentityValue { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>avatar</c> value.</summary>
    [JsonPropertyName("avatar")]
    public string? Avatar { get; init; }

    /// <summary>Gets the upstream <c>website</c> value.</summary>
    [JsonPropertyName("website")]
    public string? Website { get; init; }

    /// <summary>Gets the upstream <c>twitter</c> value.</summary>
    [JsonPropertyName("twitter")]
    public string? Twitter { get; init; }

    /// <summary>Gets the upstream <c>location</c> value.</summary>
    [JsonPropertyName("location")]
    public string? Location { get; init; }

    /// <summary>Gets the upstream <c>score</c> value.</summary>
    [JsonPropertyName("score")]
    public decimal? Score { get; init; }

    /// <summary>Gets the upstream <c>validators</c> value.</summary>
    [JsonPropertyName("validators")]
    public long? Validators { get; init; }

    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>topUp</c> value.</summary>
    [JsonPropertyName("topUp")]
    public BigInteger? TopUp { get; init; }

    /// <summary>Gets the upstream <c>locked</c> value.</summary>
    [JsonPropertyName("locked")]
    public BigInteger? Locked { get; init; }

    /// <summary>Gets the upstream <c>distribution</c> value.</summary>
    [JsonPropertyName("distribution")]
    public IReadOnlyDictionary<string, decimal>? Distribution { get; init; }

    /// <summary>Gets the upstream <c>providers</c> value.</summary>
    [JsonPropertyName("providers")]
    public IReadOnlyList<string>? Providers { get; init; }

    /// <summary>Gets the upstream <c>stakePercent</c> value.</summary>
    [JsonPropertyName("stakePercent")]
    public decimal? StakePercent { get; init; }

    /// <summary>Gets the upstream <c>rank</c> value.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; init; }

    /// <summary>Gets the upstream <c>apr</c> value.</summary>
    [JsonPropertyName("apr")]
    public decimal? Apr { get; init; }

}
