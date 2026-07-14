#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountDelegation response returned by the MultiversX API.</summary>
public sealed class AccountDelegation
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>contract</c> value.</summary>
    [JsonPropertyName("contract")]
    public string? Contract { get; init; }

    /// <summary>Gets the upstream <c>userUnBondable</c> value.</summary>
    [JsonPropertyName("userUnBondable")]
    public BigInteger? UserUnBondable { get; init; }

    /// <summary>Gets the upstream <c>userActiveStake</c> value.</summary>
    [JsonPropertyName("userActiveStake")]
    public BigInteger? UserActiveStake { get; init; }

    /// <summary>Gets the upstream <c>claimableRewards</c> value.</summary>
    [JsonPropertyName("claimableRewards")]
    public BigInteger? ClaimableRewards { get; init; }

    /// <summary>Gets the upstream <c>userUndelegatedList</c> value.</summary>
    [JsonPropertyName("userUndelegatedList")]
    public IReadOnlyList<AccountUndelegation>? UserUndelegatedList { get; init; }

}
