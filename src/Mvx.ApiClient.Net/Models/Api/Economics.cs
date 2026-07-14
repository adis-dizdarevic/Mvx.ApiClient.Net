#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Economics response returned by the MultiversX API.</summary>
public sealed class Economics
{
    /// <summary>Gets the upstream <c>totalSupply</c> value.</summary>
    [JsonPropertyName("totalSupply")]
    public decimal? TotalSupply { get; init; }

    /// <summary>Gets the upstream <c>circulatingSupply</c> value.</summary>
    [JsonPropertyName("circulatingSupply")]
    public decimal? CirculatingSupply { get; init; }

    /// <summary>Gets the upstream <c>staked</c> value.</summary>
    [JsonPropertyName("staked")]
    public decimal? Staked { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>marketCap</c> value.</summary>
    [JsonPropertyName("marketCap")]
    public decimal? MarketCap { get; init; }

    /// <summary>Gets the upstream <c>apr</c> value.</summary>
    [JsonPropertyName("apr")]
    public decimal? Apr { get; init; }

    /// <summary>Gets the upstream <c>topUpApr</c> value.</summary>
    [JsonPropertyName("topUpApr")]
    public decimal? TopUpApr { get; init; }

    /// <summary>Gets the upstream <c>baseApr</c> value.</summary>
    [JsonPropertyName("baseApr")]
    public decimal? BaseApr { get; init; }

    /// <summary>Gets the upstream <c>tokenMarketCap</c> value.</summary>
    [JsonPropertyName("tokenMarketCap")]
    public decimal? TokenMarketCap { get; init; }

}
