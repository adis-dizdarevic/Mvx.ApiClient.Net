using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.XExchange;

/// <summary>
/// xExchange farm.
/// </summary>
/// <param name="Type">The farm category.</param>
/// <param name="Version">The farm contract version, when reported by the API.</param>
/// <param name="Address">The smart contract address of the farm.</param>
/// <param name="Id">The farm token identifier.</param>
/// <param name="Symbol">The farm token ticker symbol.</param>
/// <param name="Name">The farm token display name.</param>
/// <param name="Price">The farm token price reported by the API.</param>
/// <param name="FarmingId">The identifier of the token deposited for farming.</param>
/// <param name="FarmingSymbol">The ticker symbol of the token deposited for farming.</param>
/// <param name="FarmingName">The display name of the token deposited for farming.</param>
/// <param name="FarmingPrice">The price of the token deposited for farming.</param>
/// <param name="FarmedId">The identifier of the reward token.</param>
/// <param name="FarmedSymbol">The ticker symbol of the reward token.</param>
/// <param name="FarmedName">The display name of the reward token.</param>
/// <param name="FarmedPrice">The price of the reward token.</param>
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
