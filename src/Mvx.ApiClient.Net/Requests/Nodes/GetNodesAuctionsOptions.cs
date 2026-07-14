#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nodes;

/// <summary>Optional filters for /nodes/auctions.</summary>
public sealed class GetNodesAuctionsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public GetNodesAuctionsOptionsSort? Sort { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetNodesAuctionsOptionsOrder? Order { get; init; }

}
