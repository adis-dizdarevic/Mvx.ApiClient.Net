#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Marketplace;

/// <summary>Optional filters for /accounts/{address}/auctions.</summary>
public sealed class GetAccountAuctionsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public string? Status { get; init; }

}
