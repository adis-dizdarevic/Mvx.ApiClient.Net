#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nodes;

/// <summary>Optional filters for /nodes.</summary>
public sealed class GetNodesOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>keys</c> filter.</summary>
    public IReadOnlyCollection<string>? Keys { get; init; }

    /// <summary>Gets or sets the <c>online</c> filter.</summary>
    public bool? Online { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public GetNodesOptionsType? Type { get; init; }

    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public GetNodesOptionsStatus? Status { get; init; }

    /// <summary>Gets or sets the <c>shard</c> filter.</summary>
    public long? Shard { get; init; }

    /// <summary>Gets or sets the <c>issues</c> filter.</summary>
    public bool? Issues { get; init; }

    /// <summary>Gets or sets the <c>identity</c> filter.</summary>
    public string? Identity { get; init; }

    /// <summary>Gets or sets the <c>provider</c> filter.</summary>
    public string? Provider { get; init; }

    /// <summary>Gets or sets the <c>owner</c> filter.</summary>
    public string? Owner { get; init; }

    /// <summary>Gets or sets the <c>auctioned</c> filter.</summary>
    public bool? Auctioned { get; init; }

    /// <summary>Gets or sets the <c>fullHistory</c> filter.</summary>
    public bool? FullHistory { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public GetNodesOptionsSort? Sort { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetNodesOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>withIdentityInfo</c> filter.</summary>
    public bool? WithIdentityInfo { get; init; }

    /// <summary>Gets or sets the <c>isQualified</c> filter.</summary>
    public bool? IsQualified { get; init; }

    /// <summary>Gets or sets the <c>isAuctioned</c> filter.</summary>
    public bool? IsAuctioned { get; init; }

    /// <summary>Gets or sets the <c>isAuctionDangerZone</c> filter.</summary>
    public bool? IsAuctionDangerZone { get; init; }

}
