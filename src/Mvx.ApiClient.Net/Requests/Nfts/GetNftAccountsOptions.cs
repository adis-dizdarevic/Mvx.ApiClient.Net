#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nfts;

/// <summary>Optional filters for /nfts/{identifier}/accounts.</summary>
public sealed class GetNftAccountsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
