#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Provider response returned by the MultiversX API.</summary>
public sealed class Provider
{
    /// <summary>Gets the upstream <c>numNodes</c> value.</summary>
    [JsonPropertyName("numNodes")]
    public long? NumNodes { get; init; }

    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>topUp</c> value.</summary>
    [JsonPropertyName("topUp")]
    public BigInteger? TopUp { get; init; }

    /// <summary>Gets the upstream <c>locked</c> value.</summary>
    [JsonPropertyName("locked")]
    public BigInteger? Locked { get; init; }

    /// <summary>Gets the upstream <c>provider</c> value.</summary>
    [JsonPropertyName("provider")]
    public string? ProviderValue { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>featured</c> value.</summary>
    [JsonPropertyName("featured")]
    public bool? Featured { get; init; }

    /// <summary>Gets the upstream <c>serviceFee</c> value.</summary>
    [JsonPropertyName("serviceFee")]
    public decimal? ServiceFee { get; init; }

    /// <summary>Gets the upstream <c>delegationCap</c> value.</summary>
    [JsonPropertyName("delegationCap")]
    public BigInteger? DelegationCap { get; init; }

    /// <summary>Gets the upstream <c>apr</c> value.</summary>
    [JsonPropertyName("apr")]
    public decimal? Apr { get; init; }

    /// <summary>Gets the upstream <c>numUsers</c> value.</summary>
    [JsonPropertyName("numUsers")]
    public long? NumUsers { get; init; }

    /// <summary>Gets the upstream <c>cumulatedRewards</c> value.</summary>
    [JsonPropertyName("cumulatedRewards")]
    public BigInteger? CumulatedRewards { get; init; }

    /// <summary>Gets the upstream <c>identity</c> value.</summary>
    [JsonPropertyName("identity")]
    public string? Identity { get; init; }

    /// <summary>Gets the upstream <c>initialOwnerFunds</c> value.</summary>
    [JsonPropertyName("initialOwnerFunds")]
    public BigInteger? InitialOwnerFunds { get; init; }

    /// <summary>Gets the upstream <c>automaticActivation</c> value.</summary>
    [JsonPropertyName("automaticActivation")]
    public bool? AutomaticActivation { get; init; }

    /// <summary>Gets the upstream <c>checkCapOnRedelegate</c> value.</summary>
    [JsonPropertyName("checkCapOnRedelegate")]
    public bool? CheckCapOnRedelegate { get; init; }

    /// <summary>Gets the upstream <c>ownerBelowRequiredBalanceThreshold</c> value.</summary>
    [JsonPropertyName("ownerBelowRequiredBalanceThreshold")]
    public bool? OwnerBelowRequiredBalanceThreshold { get; init; }

    /// <summary>Gets the upstream <c>totalUnStaked</c> value.</summary>
    [JsonPropertyName("totalUnStaked")]
    public BigInteger? TotalUnStaked { get; init; }

    /// <summary>Gets the upstream <c>createdNonce</c> value.</summary>
    [JsonPropertyName("createdNonce")]
    public long? CreatedNonce { get; init; }

    /// <summary>Gets the upstream <c>githubProfileValidated</c> value.</summary>
    [JsonPropertyName("githubProfileValidated")]
    public bool? GithubProfileValidated { get; init; }

    /// <summary>Gets the upstream <c>githubProfileValidatedAt</c> value.</summary>
    [JsonPropertyName("githubProfileValidatedAt")]
    public string? GithubProfileValidatedAt { get; init; }

    /// <summary>Gets the upstream <c>githubKeysValidated</c> value.</summary>
    [JsonPropertyName("githubKeysValidated")]
    public bool? GithubKeysValidated { get; init; }

    /// <summary>Gets the upstream <c>githubKeysValidatedAt</c> value.</summary>
    [JsonPropertyName("githubKeysValidatedAt")]
    public string? GithubKeysValidatedAt { get; init; }

    /// <summary>Gets the upstream <c>identityInfo</c> value.</summary>
    [JsonPropertyName("identityInfo")]
    public Identity? IdentityInfo { get; init; }

}
