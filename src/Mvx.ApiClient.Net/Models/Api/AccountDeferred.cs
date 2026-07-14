#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountDeferred response returned by the MultiversX API.</summary>
public sealed class AccountDeferred
{
    /// <summary>Gets the upstream <c>deferredPayment</c> value.</summary>
    [JsonPropertyName("deferredPayment")]
    public BigInteger? DeferredPayment { get; init; }

    /// <summary>Gets the upstream <c>secondsLeft</c> value.</summary>
    [JsonPropertyName("secondsLeft")]
    public long? SecondsLeft { get; init; }

}
