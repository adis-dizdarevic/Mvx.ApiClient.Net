using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange pair.
/// </summary>
public sealed record XExchangePairDto(
    [property: JsonPropertyName("address")]
    string Address,

    [property: JsonPropertyName("id")]
    string Id,

    [property: JsonPropertyName("symbol")]
    string Symbol,

    [property: JsonPropertyName("name")]
    string Name,

    [property: JsonPropertyName("price")]
    double Price,

    [property: JsonPropertyName("basePrevious24hPrice")]
    double BasePreviousPrice,

    [property: JsonPropertyName("quotePrevious24hPrice")]
    double QuotePreviousPrice,

    [property: JsonPropertyName("baseId")]
    string BaseId,

    [property: JsonPropertyName("baseSymbol")]
    string BaseSymbol,

    [property: JsonPropertyName("baseName")]
    string BaseName,

    [property: JsonPropertyName("basePrice")]
    double BasePrice,

    [property: JsonPropertyName("quoteId")]
    string QuoteId,

    [property: JsonPropertyName("quoteSymbol")]
    string QuoteSymbol,

    [property: JsonPropertyName("quoteName")]
    string QuoteName,

    [property: JsonPropertyName("quotePrice")]
    double QuotePrice,

    [property: JsonPropertyName("totalValue")]
    double TotalValue,

    [property: JsonPropertyName("volume24h")]
    double Volume,

    [property: JsonPropertyName("state")]
    XExchangePairState State,

    [property: JsonPropertyName("type")]
    XExchangePairType Type,

    [property: JsonPropertyName("exchange")]
    string Exchange,

    [property: JsonPropertyName("hasFarms")]
    bool HasFarms,

    [property: JsonPropertyName("hasDualFarms")]
    bool HasDualFarms,

    [property: JsonPropertyName("tradesCount")]
    long TradesCount,

    [property: JsonPropertyName("tradesCount24h")]
    long PreviousTradesCount,

    [property: JsonPropertyName("deployedAt")]
    long DeployedAt
);

/// <summary>
/// xExchange pair state.
/// </summary>
public enum XExchangePairState
{
    /// <summary>
    /// Active pair.
    /// </summary>
    Active,

    /// <summary>
    /// Inactive pair.
    /// </summary>
    Inactive,

    /// <summary>
    /// Paused pair.
    /// </summary>
    Paused,

    /// <summary>
    /// Partially active pair.
    /// </summary>
    Partial
}

/// <summary>
/// xExchange pair category.
/// </summary>
public enum XExchangePairType
{
    /// <summary>
    /// Core xExchange pair.
    /// </summary>
    Core,

    /// <summary>
    /// Community xExchange pair.
    /// </summary>
    Community,

    /// <summary>
    /// Ecosystem xExchange pair.
    /// </summary>
    Ecosystem,

    /// <summary>
    /// Experimental xExchange pair.
    /// </summary>
    Experimental,

    /// <summary>
    /// Unlisted xExchange pair.
    /// </summary>
    Unlisted
}
