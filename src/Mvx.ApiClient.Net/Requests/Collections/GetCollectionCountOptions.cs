#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Optional filters for /collections/count.</summary>
public sealed class GetCollectionCountOptions
{
    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public IReadOnlyCollection<string>? Type { get; init; }

    /// <summary>Gets or sets the <c>subType</c> filter.</summary>
    public IReadOnlyCollection<string>? SubType { get; init; }

    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

    /// <summary>Gets or sets the <c>canCreate</c> filter.</summary>
    public string? CanCreate { get; init; }

    /// <summary>Gets or sets the <c>canBurn</c> filter.</summary>
    public string? CanBurn { get; init; }

    /// <summary>Gets or sets the <c>canAddQuantity</c> filter.</summary>
    public string? CanAddQuantity { get; init; }

    /// <summary>Gets or sets the <c>canUpdateAttributes</c> filter.</summary>
    public string? CanUpdateAttributes { get; init; }

    /// <summary>Gets or sets the <c>canAddUri</c> filter.</summary>
    public string? CanAddUri { get; init; }

    /// <summary>Gets or sets the <c>canTransferRole</c> filter.</summary>
    public string? CanTransferRole { get; init; }

    /// <summary>Gets or sets the <c>excludeMetaESDT</c> filter.</summary>
    public bool? ExcludeMetaESDT { get; init; }

}
