#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the TransactionReceipt response returned by the MultiversX API.</summary>
public sealed class TransactionReceipt
{
    /// <summary>Gets the upstream <c>value</c> value.</summary>
    [JsonPropertyName("value")]
    public BigInteger? Value { get; init; }

    /// <summary>Gets the upstream <c>sender</c> value.</summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; init; }

    /// <summary>Gets the upstream <c>data</c> value.</summary>
    [JsonPropertyName("data")]
    public string? Data { get; init; }

}
