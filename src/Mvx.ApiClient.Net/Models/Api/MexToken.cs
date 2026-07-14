#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MexToken response returned by the MultiversX API.</summary>
public sealed class MexToken
{
    /// <summary>Gets the upstream <c>id</c> value.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the upstream <c>symbol</c> value.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>previous24hPrice</c> value.</summary>
    [JsonPropertyName("previous24hPrice")]
    public decimal? Previous24HPrice { get; init; }

    /// <summary>Gets the upstream <c>previous24hVolume</c> value.</summary>
    [JsonPropertyName("previous24hVolume")]
    public decimal? Previous24HVolume { get; init; }

    /// <summary>Gets the upstream <c>tradesCount</c> value.</summary>
    [JsonPropertyName("tradesCount")]
    public long? TradesCount { get; init; }

}
