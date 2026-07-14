#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountDelegationLegacy response returned by the MultiversX API.</summary>
public sealed class AccountDelegationLegacy
{
    /// <summary>Gets the upstream <c>claimableRewards</c> value.</summary>
    [JsonPropertyName("claimableRewards")]
    public BigInteger? ClaimableRewards { get; init; }

    /// <summary>Gets the upstream <c>userActiveStake</c> value.</summary>
    [JsonPropertyName("userActiveStake")]
    public BigInteger? UserActiveStake { get; init; }

    /// <summary>Gets the upstream <c>userDeferredPaymentStake</c> value.</summary>
    [JsonPropertyName("userDeferredPaymentStake")]
    public BigInteger? UserDeferredPaymentStake { get; init; }

    /// <summary>Gets the upstream <c>userUnstakedStake</c> value.</summary>
    [JsonPropertyName("userUnstakedStake")]
    public BigInteger? UserUnstakedStake { get; init; }

    /// <summary>Gets the upstream <c>userWaitingStake</c> value.</summary>
    [JsonPropertyName("userWaitingStake")]
    public BigInteger? UserWaitingStake { get; init; }

    /// <summary>Gets the upstream <c>userWithdrawOnlyStake</c> value.</summary>
    [JsonPropertyName("userWithdrawOnlyStake")]
    public BigInteger? UserWithdrawOnlyStake { get; init; }

}
