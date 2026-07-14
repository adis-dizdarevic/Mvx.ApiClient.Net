#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MexPair response returned by the MultiversX API.</summary>
public sealed class MexPair
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

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

    /// <summary>Gets the upstream <c>basePrevious24hPrice</c> value.</summary>
    [JsonPropertyName("basePrevious24hPrice")]
    public decimal? BasePrevious24HPrice { get; init; }

    /// <summary>Gets the upstream <c>quotePrevious24hPrice</c> value.</summary>
    [JsonPropertyName("quotePrevious24hPrice")]
    public decimal? QuotePrevious24HPrice { get; init; }

    /// <summary>Gets the upstream <c>baseId</c> value.</summary>
    [JsonPropertyName("baseId")]
    public string? BaseId { get; init; }

    /// <summary>Gets the upstream <c>baseSymbol</c> value.</summary>
    [JsonPropertyName("baseSymbol")]
    public string? BaseSymbol { get; init; }

    /// <summary>Gets the upstream <c>baseName</c> value.</summary>
    [JsonPropertyName("baseName")]
    public string? BaseName { get; init; }

    /// <summary>Gets the upstream <c>basePrice</c> value.</summary>
    [JsonPropertyName("basePrice")]
    public decimal? BasePrice { get; init; }

    /// <summary>Gets the upstream <c>quoteId</c> value.</summary>
    [JsonPropertyName("quoteId")]
    public string? QuoteId { get; init; }

    /// <summary>Gets the upstream <c>quoteSymbol</c> value.</summary>
    [JsonPropertyName("quoteSymbol")]
    public string? QuoteSymbol { get; init; }

    /// <summary>Gets the upstream <c>quoteName</c> value.</summary>
    [JsonPropertyName("quoteName")]
    public string? QuoteName { get; init; }

    /// <summary>Gets the upstream <c>quotePrice</c> value.</summary>
    [JsonPropertyName("quotePrice")]
    public decimal? QuotePrice { get; init; }

    /// <summary>Gets the upstream <c>totalValue</c> value.</summary>
    [JsonPropertyName("totalValue")]
    public decimal? TotalValue { get; init; }

    /// <summary>Gets the upstream <c>volume24h</c> value.</summary>
    [JsonPropertyName("volume24h")]
    public decimal? Volume24H { get; init; }

    /// <summary>Gets the upstream <c>state</c> value.</summary>
    [JsonPropertyName("state")]
    public MexPairState? State { get; init; }

    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public MexPairType? Type { get; init; }

    /// <summary>Gets the upstream <c>exchange</c> value.</summary>
    [JsonPropertyName("exchange")]
    public string? Exchange { get; init; }

    /// <summary>Gets the upstream <c>tradesCount</c> value.</summary>
    [JsonPropertyName("tradesCount")]
    public long? TradesCount { get; init; }

    /// <summary>Gets the upstream <c>tradesCount24h</c> value.</summary>
    [JsonPropertyName("tradesCount24h")]
    public long? TradesCount24H { get; init; }

    /// <summary>Gets the upstream <c>deployedAt</c> value.</summary>
    [JsonPropertyName("deployedAt")]
    public long? DeployedAt { get; init; }

    /// <summary>Gets the upstream <c>hasFarms</c> value.</summary>
    [JsonPropertyName("hasFarms")]
    public bool? HasFarms { get; init; }

    /// <summary>Gets the upstream <c>hasDualFarms</c> value.</summary>
    [JsonPropertyName("hasDualFarms")]
    public bool? HasDualFarms { get; init; }

}
