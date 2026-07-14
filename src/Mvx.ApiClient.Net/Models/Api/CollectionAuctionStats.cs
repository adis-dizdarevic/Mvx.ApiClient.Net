#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the CollectionAuctionStats response returned by the MultiversX API.</summary>
public sealed class CollectionAuctionStats
{
    /// <summary>Gets the upstream <c>activeAuctions</c> value.</summary>
    [JsonPropertyName("activeAuctions")]
    public long? ActiveAuctions { get; init; }

    /// <summary>Gets the upstream <c>endedAuctions</c> value.</summary>
    [JsonPropertyName("endedAuctions")]
    public long? EndedAuctions { get; init; }

    /// <summary>Gets the upstream <c>maxPrice</c> value.</summary>
    [JsonPropertyName("maxPrice")]
    public string? MaxPrice { get; init; }

    /// <summary>Gets the upstream <c>minPrice</c> value.</summary>
    [JsonPropertyName("minPrice")]
    public string? MinPrice { get; init; }

    /// <summary>Gets the upstream <c>saleAverage</c> value.</summary>
    [JsonPropertyName("saleAverage")]
    public string? SaleAverage { get; init; }

    /// <summary>Gets the upstream <c>volumeTraded</c> value.</summary>
    [JsonPropertyName("volumeTraded")]
    public string? VolumeTraded { get; init; }

}
