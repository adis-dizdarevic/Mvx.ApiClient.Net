#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountUndelegation response returned by the MultiversX API.</summary>
public sealed class AccountUndelegation
{
    /// <summary>Gets the upstream <c>amount</c> value.</summary>
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; init; }

    /// <summary>Gets the upstream <c>seconds</c> value.</summary>
    [JsonPropertyName("seconds")]
    public long? Seconds { get; init; }

}
