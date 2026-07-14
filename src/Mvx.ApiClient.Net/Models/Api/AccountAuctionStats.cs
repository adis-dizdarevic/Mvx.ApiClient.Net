#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountAuctionStats response returned by the MultiversX API.</summary>
public sealed class AccountAuctionStats
{
    /// <summary>Gets the upstream <c>auctions</c> value.</summary>
    [JsonPropertyName("auctions")]
    public long? Auctions { get; init; }

    /// <summary>Gets the upstream <c>claimable</c> value.</summary>
    [JsonPropertyName("claimable")]
    public long? Claimable { get; init; }

    /// <summary>Gets the upstream <c>collected</c> value.</summary>
    [JsonPropertyName("collected")]
    public long? Collected { get; init; }

    /// <summary>Gets the upstream <c>collections</c> value.</summary>
    [JsonPropertyName("collections")]
    public long? Collections { get; init; }

    /// <summary>Gets the upstream <c>creations</c> value.</summary>
    [JsonPropertyName("creations")]
    public long? Creations { get; init; }

    /// <summary>Gets the upstream <c>likes</c> value.</summary>
    [JsonPropertyName("likes")]
    public long? Likes { get; init; }

    /// <summary>Gets the upstream <c>orders</c> value.</summary>
    [JsonPropertyName("orders")]
    public long? Orders { get; init; }

}
