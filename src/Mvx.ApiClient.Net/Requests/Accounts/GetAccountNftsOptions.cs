#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/nfts.</summary>
public sealed class GetAccountNftsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>identifiers</c> filter.</summary>
    public IReadOnlyCollection<string>? Identifiers { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public IReadOnlyCollection<string>? Type { get; init; }

    /// <summary>Gets or sets the <c>subType</c> filter.</summary>
    public IReadOnlyCollection<string>? SubType { get; init; }

    /// <summary>Gets or sets the <c>collections</c> filter.</summary>
    public IReadOnlyCollection<string>? Collections { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>tags</c> filter.</summary>
    public IReadOnlyCollection<string>? Tags { get; init; }

    /// <summary>Gets or sets the <c>creator</c> filter.</summary>
    public string? Creator { get; init; }

    /// <summary>Gets or sets the <c>hasUris</c> filter.</summary>
    public bool? HasUris { get; init; }

    /// <summary>Gets or sets the <c>includeFlagged</c> filter.</summary>
    public bool? IncludeFlagged { get; init; }

    /// <summary>Gets or sets the <c>withSupply</c> filter.</summary>
    public bool? WithSupply { get; init; }

    /// <summary>Gets or sets the <c>source</c> filter.</summary>
    public string? Source { get; init; }

    /// <summary>Gets or sets the <c>excludeMetaESDT</c> filter.</summary>
    public bool? ExcludeMetaESDT { get; init; }

    /// <summary>Gets or sets the <c>isScam</c> filter.</summary>
    public bool? IsScam { get; init; }

    /// <summary>Gets or sets the <c>scamType</c> filter.</summary>
    public string? ScamType { get; init; }

    /// <summary>Gets or sets the <c>timestamp</c> filter.</summary>
    public long? Timestamp { get; init; }

    /// <summary>Gets or sets the <c>withReceivedAt</c> filter.</summary>
    public bool? WithReceivedAt { get; init; }

    /// <summary>Gets or sets the <c>computeScamInfo</c> filter.</summary>
    public bool? ComputeScamInfo { get; init; }

    /// <summary>Gets or sets the <c>withScamInfo</c> filter.</summary>
    public bool? WithScamInfo { get; init; }

}
