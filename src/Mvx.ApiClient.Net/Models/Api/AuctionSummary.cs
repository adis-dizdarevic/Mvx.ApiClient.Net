#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AuctionSummary response returned by the MultiversX API.</summary>
public sealed class AuctionSummary
{
    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>auctionId</c> value.</summary>
    [JsonPropertyName("auctionId")]
    public long? AuctionId { get; init; }

    /// <summary>Gets the upstream <c>identifier</c> value.</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; init; }

    /// <summary>Gets the upstream <c>collection</c> value.</summary>
    [JsonPropertyName("collection")]
    public string? Collection { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public AuctionSummaryStatus? Status { get; init; }

    /// <summary>Gets the upstream <c>auctionType</c> value.</summary>
    [JsonPropertyName("auctionType")]
    public string? AuctionType { get; init; }

    /// <summary>Gets the upstream <c>createdAt</c> value.</summary>
    [JsonPropertyName("createdAt")]
    public long? CreatedAt { get; init; }

    /// <summary>Gets the upstream <c>endsAt</c> value.</summary>
    [JsonPropertyName("endsAt")]
    public long? EndsAt { get; init; }

    /// <summary>Gets the upstream <c>marketplaceAuctionId</c> value.</summary>
    [JsonPropertyName("marketplaceAuctionId")]
    public long? MarketplaceAuctionId { get; init; }

    /// <summary>Gets the upstream <c>marketplace</c> value.</summary>
    [JsonPropertyName("marketplace")]
    public string? Marketplace { get; init; }

    /// <summary>Gets the upstream <c>minBid</c> value.</summary>
    [JsonPropertyName("minBid")]
    public Bid? MinBid { get; init; }

    /// <summary>Gets the upstream <c>maxBid</c> value.</summary>
    [JsonPropertyName("maxBid")]
    public Bid? MaxBid { get; init; }

}
