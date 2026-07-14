#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the DelegationLegacy response returned by the MultiversX API.</summary>
public sealed class DelegationLegacy
{
    /// <summary>Gets the upstream <c>totalWithdrawOnlyStake</c> value.</summary>
    [JsonPropertyName("totalWithdrawOnlyStake")]
    public BigInteger? TotalWithdrawOnlyStake { get; init; }

    /// <summary>Gets the upstream <c>totalWaitingStake</c> value.</summary>
    [JsonPropertyName("totalWaitingStake")]
    public BigInteger? TotalWaitingStake { get; init; }

    /// <summary>Gets the upstream <c>totalActiveStake</c> value.</summary>
    [JsonPropertyName("totalActiveStake")]
    public BigInteger? TotalActiveStake { get; init; }

    /// <summary>Gets the upstream <c>totalUnstakedStake</c> value.</summary>
    [JsonPropertyName("totalUnstakedStake")]
    public BigInteger? TotalUnstakedStake { get; init; }

    /// <summary>Gets the upstream <c>totalDeferredPaymentStake</c> value.</summary>
    [JsonPropertyName("totalDeferredPaymentStake")]
    public BigInteger? TotalDeferredPaymentStake { get; init; }

    /// <summary>Gets the upstream <c>numUsers</c> value.</summary>
    [JsonPropertyName("numUsers")]
    public long? NumUsers { get; init; }

}
