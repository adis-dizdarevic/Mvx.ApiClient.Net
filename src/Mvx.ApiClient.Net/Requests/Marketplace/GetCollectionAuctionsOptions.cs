#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Marketplace;

/// <summary>Optional filters for /collections/{collection}/auctions.</summary>
public sealed class GetCollectionAuctionsOptions
{
    /// <summary>Gets or sets the <c>size</c> filter.</summary>
    public long? Size { get; init; }

}
