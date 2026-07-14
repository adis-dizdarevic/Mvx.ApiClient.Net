#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Optional filters for /collections/{collection}/nfts.</summary>
public sealed class GetNftsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>identifiers</c> filter.</summary>
    public IReadOnlyCollection<string>? Identifiers { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>tags</c> filter.</summary>
    public IReadOnlyCollection<string>? Tags { get; init; }

    /// <summary>Gets or sets the <c>creator</c> filter.</summary>
    public string? Creator { get; init; }

    /// <summary>Gets or sets the <c>isWhitelistedStorage</c> filter.</summary>
    public bool? IsWhitelistedStorage { get; init; }

    /// <summary>Gets or sets the <c>hasUris</c> filter.</summary>
    public bool? HasUris { get; init; }

    /// <summary>Gets or sets the <c>isNsfw</c> filter.</summary>
    public bool? IsNsfw { get; init; }

    /// <summary>Gets or sets the <c>nonceBefore</c> filter.</summary>
    public long? NonceBefore { get; init; }

    /// <summary>Gets or sets the <c>nonceAfter</c> filter.</summary>
    public long? NonceAfter { get; init; }

    /// <summary>Gets or sets the <c>withOwner</c> filter.</summary>
    public bool? WithOwner { get; init; }

    /// <summary>Gets or sets the <c>withSupply</c> filter.</summary>
    public bool? WithSupply { get; init; }

    /// <summary>Gets or sets the <c>withAssets</c> filter.</summary>
    public bool? WithAssets { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public GetNftsOptionsSort? Sort { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetNftsOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>traits</c> filter.</summary>
    public bool? Traits { get; init; }

}
