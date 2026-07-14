#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the CollectionAccount response returned by the MultiversX API.</summary>
public sealed class CollectionAccount
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

}
