using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange economics information.
/// </summary>
public sealed record XExchangeEconomicsDto(
    [property: JsonPropertyName("totalSupply")]
    long TotalSupply,

    [property: JsonPropertyName("circulatingSupply")]
    long CirculatingSupply,

    [property: JsonPropertyName("price")]
    double Price,

    [property: JsonPropertyName("marketCap")]
    long MarketCap,

    [property: JsonPropertyName("volume24h")]
    long Volume,

    [property: JsonPropertyName("marketPairs")]
    int MarketPairs
);
