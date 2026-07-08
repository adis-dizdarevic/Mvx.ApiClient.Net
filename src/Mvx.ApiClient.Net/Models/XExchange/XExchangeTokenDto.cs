using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange token.
/// </summary>
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
