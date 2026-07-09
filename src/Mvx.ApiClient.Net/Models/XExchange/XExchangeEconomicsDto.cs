using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange economics information.
/// </summary>
/// <param name="TotalSupply">The total MEX supply reported by the API.</param>
/// <param name="CirculatingSupply">The circulating MEX supply reported by the API.</param>
/// <param name="Price">The current MEX price reported by the API.</param>
/// <param name="MarketCap">The current MEX market capitalization.</param>
/// <param name="Volume">The xExchange trading volume for the previous 24-hour window.</param>
/// <param name="MarketPairs">The number of market pairs tracked by xExchange.</param>
public sealed record XExchangeEconomicsDto(
    [property: JsonPropertyName("totalSupply")]
    long TotalSupply,

    [property: JsonPropertyName("circulatingSupply")]
    long CirculatingSupply,

    [property: JsonPropertyName("price")]
    decimal Price,

    [property: JsonPropertyName("marketCap")]
    decimal MarketCap,

    [property: JsonPropertyName("volume24h")]
    decimal Volume,

    [property: JsonPropertyName("marketPairs")]
    int MarketPairs
);
