using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Mex;

/// <summary>
/// xExchange farm.
/// </summary>
/// <param name="Type">Farm type.</param>
/// <param name="Version">Farm version.</param>
/// <param name="Address">Farm smart contract address.</param>
/// <param name="Id">Farm identifier.</param>
/// <param name="Symbol">Farm symbol.</param>
/// <param name="Name">Farm name.</param>
/// <param name="Price">Farm token price.</param>
/// <param name="FarmingId">Farming token identifier.</param>
/// <param name="FarmingSymbol">Farming token symbol.</param>
/// <param name="FarmingName">Farming token name.</param>
/// <param name="FarmingPrice">Farming token price.</param>
/// <param name="FarmedId">Farmed token identifier.</param>
/// <param name="FarmedSymbol">Farmed token symbol.</param>
/// <param name="FarmedName">Farmed token name.</param>
/// <param name="FarmedPrice">Farmed token price.</param>
public record MexFarmDto(
    [property: JsonPropertyName("type")]
    MexFarmType Type,
    
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
public enum MexFarmType
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
