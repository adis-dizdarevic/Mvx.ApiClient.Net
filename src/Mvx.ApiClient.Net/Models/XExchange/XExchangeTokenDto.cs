using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange token.
/// </summary>
/// <param name="Id">The token identifier.</param>
/// <param name="Symbol">The token ticker symbol.</param>
/// <param name="Name">The display name of the token.</param>
/// <param name="Price">The latest token price reported by the API.</param>
/// <param name="PreviousPrice">The token price reported for the previous 24-hour window.</param>
/// <param name="PreviousVolume">The token trading volume reported for the previous 24-hour window.</param>
/// <param name="TradesCount">The total number of recorded trades for the token.</param>
public sealed record XExchangeTokenDto(
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
