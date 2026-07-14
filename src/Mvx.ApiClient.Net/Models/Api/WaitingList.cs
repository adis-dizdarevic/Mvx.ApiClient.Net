#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the WaitingList response returned by the MultiversX API.</summary>
public sealed class WaitingList
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>nonce</c> value.</summary>
    [JsonPropertyName("nonce")]
    public long? Nonce { get; init; }

    /// <summary>Gets the upstream <c>rank</c> value.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; init; }

    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

}
