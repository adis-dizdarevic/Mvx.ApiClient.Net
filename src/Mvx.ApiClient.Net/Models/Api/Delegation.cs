#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Delegation response returned by the MultiversX API.</summary>
public sealed class Delegation
{
    /// <summary>Gets the upstream <c>stake</c> value.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }

    /// <summary>Gets the upstream <c>topUp</c> value.</summary>
    [JsonPropertyName("topUp")]
    public BigInteger? TopUp { get; init; }

    /// <summary>Gets the upstream <c>locked</c> value.</summary>
    [JsonPropertyName("locked")]
    public BigInteger? Locked { get; init; }

    /// <summary>Gets the upstream <c>minDelegation</c> value.</summary>
    [JsonPropertyName("minDelegation")]
    public BigInteger? MinDelegation { get; init; }

}
