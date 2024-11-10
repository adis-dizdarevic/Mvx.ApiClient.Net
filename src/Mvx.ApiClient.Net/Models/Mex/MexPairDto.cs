using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Mex;

/// <summary>
/// xExchange Pair
/// </summary>
/// <param name="Address"></param>
/// <param name="Id"></param>
/// <param name="Symbol"></param>
/// <param name="Name"></param>
/// <param name="Price"></param>
/// <param name="BasePreviousPrice"></param>
/// <param name="QuotePreviousPrice"></param>
/// <param name="BaseId"></param>
/// <param name="BaseSymbol"></param>
/// <param name="BaseName"></param>
/// <param name="BasePrice"></param>
/// <param name="QuoteId"></param>
/// <param name="QuoteSymbol"></param>
/// <param name="QuoteName"></param>
/// <param name="QuotePrice"></param>
/// <param name="TotalValue"></param>
/// <param name="Volume"></param>
/// <param name="State"></param>
/// <param name="Type"></param>
/// <param name="Exchange"></param>
/// <param name="HasFarms"></param>
/// <param name="HasDualFarms"></param>
/// <param name="TradesCount"></param>
/// <param name="DeployedAt"></param>
public record MexPairDto(
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
    MexPairState State,
    
    [property: JsonPropertyName("type")]
    MexPairType Type,
    
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

public enum MexPairState
{
    Active,
    Inactive,
    Paused,
    Partial
}

public enum MexPairType
{
    Core,
    Community,
    Ecosystem,
    Experimental,
    Unlisted
}
