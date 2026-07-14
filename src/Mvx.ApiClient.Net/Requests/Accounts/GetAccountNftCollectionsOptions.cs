#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/collections.</summary>
public sealed class GetAccountNftCollectionsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public IReadOnlyCollection<string>? Type { get; init; }

    /// <summary>Gets or sets the <c>subType</c> filter.</summary>
    public IReadOnlyCollection<string>? SubType { get; init; }

    /// <summary>Gets or sets the <c>excludeMetaESDT</c> filter.</summary>
    public bool? ExcludeMetaESDT { get; init; }

}
