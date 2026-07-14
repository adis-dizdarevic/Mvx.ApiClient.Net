#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Bid response returned by the MultiversX API.</summary>
public sealed class Bid
{
    /// <summary>Gets the upstream <c>amount</c> value.</summary>
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; init; }

    /// <summary>Gets the upstream <c>token</c> value.</summary>
    [JsonPropertyName("token")]
    public string? Token { get; init; }

}
