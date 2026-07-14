#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Marketplace;

/// <summary>Optional filters for /auctions/count.</summary>
public sealed class GetAuctionsCountOptions
{
    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public string? Status { get; init; }

}
