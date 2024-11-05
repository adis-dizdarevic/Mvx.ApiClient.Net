using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Mex;

/// <summary>
/// xExchange Token
/// </summary>
/// <param name="Id">Token id</param>
/// <param name="Symbol">Token symbol</param>
/// <param name="Name">Token name</param>
/// <param name="Price">Current token price</param>
/// <param name="PreviousPrice">Token price in the previous 24h</param>
/// <param name="PreviousVolume">Token volume in the previous 24h</param>
/// <param name="TradesCount">Number of trades for this token</param>
public record MexTokenDto(
    [property: JsonPropertyName("id")]
    string Id,
    
    [property: JsonPropertyName("symbol")]
    string Symbol,
    
    [property: JsonPropertyName("name")]
    string Name,
    
    [property: JsonPropertyName("price")]
    double Price,
    
    [property: JsonPropertyName("previous24hPrice")]
    double PreviousPrice,
    
    [property: JsonPropertyName("previous24hVolume")]
    double PreviousVolume,
    
    [property: JsonPropertyName("tradesCount")]
    long TradesCount
);
