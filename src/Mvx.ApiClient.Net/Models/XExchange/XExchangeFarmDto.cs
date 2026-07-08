using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange farm.
/// </summary>
public sealed record XExchangeFarmDto(
    [property: JsonPropertyName("type")]
    XExchangeFarmType Type,

    [property: JsonPropertyName("version")]
    string? Version,

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

    [property: JsonPropertyName("farmingId")]
    string FarmingId,

    [property: JsonPropertyName("farmingSymbol")]
    string FarmingSymbol,

    [property: JsonPropertyName("farmingName")]
    string FarmingName,

    [property: JsonPropertyName("farmingPrice")]
    double FarmingPrice,

    [property: JsonPropertyName("farmedId")]
    string FarmedId,

    [property: JsonPropertyName("farmedSymbol")]
    string FarmedSymbol,

    [property: JsonPropertyName("farmedName")]
    string FarmedName,

    [property: JsonPropertyName("farmedPrice")]
    double FarmedPrice
);

/// <summary>
/// xExchange farm type.
/// </summary>
public enum XExchangeFarmType
{
    /// <summary>
    /// Standard farm.
    /// </summary>
    Standard,

    /// <summary>
    /// Meta-staking farm.
    /// </summary>
    MetaStaking
}
