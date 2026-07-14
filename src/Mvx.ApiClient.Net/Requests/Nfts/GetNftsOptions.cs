#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nfts;

/// <summary>Optional filters for /nfts.</summary>
public sealed class GetNftsOptions
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

    /// <summary>Gets or sets the <c>collection</c> filter.</summary>
    public string? Collection { get; init; }

    /// <summary>Gets or sets the <c>collections</c> filter.</summary>
    public IReadOnlyCollection<string>? Collections { get; init; }

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

    /// <summary>Gets or sets the <c>isScam</c> filter.</summary>
    public bool? IsScam { get; init; }

    /// <summary>Gets or sets the <c>scamType</c> filter.</summary>
    public string? ScamType { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>withOwner</c> filter.</summary>
    public bool? WithOwner { get; init; }

    /// <summary>Gets or sets the <c>withSupply</c> filter.</summary>
    public bool? WithSupply { get; init; }

    /// <summary>Gets or sets the <c>traits</c> filter.</summary>
    public bool? Traits { get; init; }

}
