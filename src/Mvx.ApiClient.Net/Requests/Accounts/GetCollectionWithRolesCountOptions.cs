#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/roles/collections/count.</summary>
public sealed class GetCollectionWithRolesCountOptions
{
    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>type</c> filter.</summary>
    public IReadOnlyCollection<string>? Type { get; init; }

    /// <summary>Gets or sets the <c>subType</c> filter.</summary>
    public IReadOnlyCollection<string>? SubType { get; init; }

    /// <summary>Gets or sets the <c>owner</c> filter.</summary>
    public string? Owner { get; init; }

    /// <summary>Gets or sets the <c>canCreate</c> filter.</summary>
    public bool? CanCreate { get; init; }

    /// <summary>Gets or sets the <c>canBurn</c> filter.</summary>
    public bool? CanBurn { get; init; }

    /// <summary>Gets or sets the <c>canAddQuantity</c> filter.</summary>
    public bool? CanAddQuantity { get; init; }

    /// <summary>Gets or sets the <c>excludeMetaESDT</c> filter.</summary>
    public bool? ExcludeMetaESDT { get; init; }

}
