#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Marketplace;

/// <summary>Optional filters for /auctions.</summary>
public sealed class GetAuctionsOptions
{
    /// <summary>Gets or sets the <c>size</c> filter.</summary>
    public long? Size { get; init; }

}
