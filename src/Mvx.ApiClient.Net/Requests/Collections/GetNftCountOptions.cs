#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Optional filters for /collections/{collection}/nfts/count.</summary>
public sealed class GetNftCountOptions
{
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

    /// <summary>Gets or sets the <c>nonceBefore</c> filter.</summary>
    public long? NonceBefore { get; init; }

    /// <summary>Gets or sets the <c>nonceAfter</c> filter.</summary>
    public long? NonceAfter { get; init; }

    /// <summary>Gets or sets the <c>traits</c> filter.</summary>
    public bool? Traits { get; init; }

}
