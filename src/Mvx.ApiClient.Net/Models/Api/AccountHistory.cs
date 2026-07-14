#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountHistory response returned by the MultiversX API.</summary>
public sealed class AccountHistory
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>isSender</c> value.</summary>
    [JsonPropertyName("isSender")]
    public bool? IsSender { get; init; }

}
