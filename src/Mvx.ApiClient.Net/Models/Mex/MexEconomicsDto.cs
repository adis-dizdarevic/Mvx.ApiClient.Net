using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Mex;

/// <summary>
/// xExchange economics
/// </summary>
/// <param name="TotalSupply">Total supply of MEX</param>
/// <param name="CirculatingSupply">Circulating supply of MEX</param>
/// <param name="Price">Current MEX price</param>
/// <param name="MarketCap">Current market cap of MEX</param>
/// <param name="Volume">Volume (24h) of MEX</param>
/// <param name="MarketPairs">Number of market pairs</param>
public record MexEconomicsDto(
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
