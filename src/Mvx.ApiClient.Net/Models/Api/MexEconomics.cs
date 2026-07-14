#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MexEconomics response returned by the MultiversX API.</summary>
public sealed class MexEconomics
{
    /// <summary>Gets the upstream <c>totalSupply</c> value.</summary>
    [JsonPropertyName("totalSupply")]
    public decimal? TotalSupply { get; init; }

    /// <summary>Gets the upstream <c>circulatingSupply</c> value.</summary>
    [JsonPropertyName("circulatingSupply")]
    public decimal? CirculatingSupply { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>marketCap</c> value.</summary>
    [JsonPropertyName("marketCap")]
    public decimal? MarketCap { get; init; }

    /// <summary>Gets the upstream <c>volume24h</c> value.</summary>
    [JsonPropertyName("volume24h")]
    public decimal? Volume24H { get; init; }

    /// <summary>Gets the upstream <c>marketPairs</c> value.</summary>
    [JsonPropertyName("marketPairs")]
    public long? MarketPairs { get; init; }

}
