using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange pair.
/// </summary>
/// <param name="Address">The smart contract address of the pair.</param>
/// <param name="Id">The pair identifier.</param>
/// <param name="Symbol">The pair ticker symbol.</param>
/// <param name="Name">The display name of the pair.</param>
/// <param name="Price">The latest pair price reported by the API.</param>
/// <param name="BasePreviousPrice">The base token price from the previous 24-hour window.</param>
/// <param name="QuotePreviousPrice">The quote token price from the previous 24-hour window.</param>
/// <param name="BaseId">The base token identifier.</param>
/// <param name="BaseSymbol">The base token ticker symbol.</param>
/// <param name="BaseName">The base token display name.</param>
/// <param name="BasePrice">The latest base token price reported by the API.</param>
/// <param name="QuoteId">The quote token identifier.</param>
/// <param name="QuoteSymbol">The quote token ticker symbol.</param>
/// <param name="QuoteName">The quote token display name.</param>
/// <param name="QuotePrice">The latest quote token price reported by the API.</param>
/// <param name="TotalValue">The total value locked in the pair.</param>
/// <param name="Volume">The pair volume for the previous 24-hour window.</param>
/// <param name="State">The current pair state.</param>
/// <param name="Type">The pair category.</param>
/// <param name="Exchange">The exchange name reported by the API.</param>
/// <param name="HasFarms">A value indicating whether the pair has farms.</param>
/// <param name="HasDualFarms">A value indicating whether the pair has dual farms.</param>
/// <param name="TradesCount">The total number of recorded trades for the pair.</param>
/// <param name="PreviousTradesCount">The number of recorded trades for the previous 24-hour window.</param>
/// <param name="DeployedAt">The Unix timestamp at which the pair contract was deployed.</param>
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
    decimal Price,

    [property: JsonPropertyName("basePrevious24hPrice")]
    decimal BasePreviousPrice,

    [property: JsonPropertyName("quotePrevious24hPrice")]
    decimal QuotePreviousPrice,

    [property: JsonPropertyName("baseId")]
    string BaseId,

    [property: JsonPropertyName("baseSymbol")]
    string BaseSymbol,

    [property: JsonPropertyName("baseName")]
    string BaseName,

    [property: JsonPropertyName("basePrice")]
    decimal BasePrice,

    [property: JsonPropertyName("quoteId")]
    string QuoteId,

    [property: JsonPropertyName("quoteSymbol")]
    string QuoteSymbol,

    [property: JsonPropertyName("quoteName")]
    string QuoteName,

    [property: JsonPropertyName("quotePrice")]
    decimal QuotePrice,

    [property: JsonPropertyName("totalValue")]
    decimal TotalValue,

    [property: JsonPropertyName("volume24h")]
    decimal Volume,

    [property: JsonPropertyName("state")]
    XExchangePairState State,

    [property: JsonPropertyName("type")]
    XExchangePairType Type,

    [property: JsonPropertyName("exchange")]
    string Exchange,

    [property: JsonPropertyName("hasFarms")]
    bool? HasFarms,

    [property: JsonPropertyName("hasDualFarms")]
    bool? HasDualFarms,

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
