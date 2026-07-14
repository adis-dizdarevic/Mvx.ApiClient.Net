#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Optional filters for /collections/{identifier}/accounts.</summary>
public sealed class GetCollectionAccountsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
