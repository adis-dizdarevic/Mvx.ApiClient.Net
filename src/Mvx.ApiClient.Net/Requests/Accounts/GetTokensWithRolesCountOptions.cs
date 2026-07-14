#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/roles/tokens/count.</summary>
public sealed class GetTokensWithRolesCountOptions
{
    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>owner</c> filter.</summary>
    public string? Owner { get; init; }

    /// <summary>Gets or sets the <c>canMint</c> filter.</summary>
    public bool? CanMint { get; init; }

    /// <summary>Gets or sets the <c>canBurn</c> filter.</summary>
    public bool? CanBurn { get; init; }

    /// <summary>Gets or sets the <c>includeMetaESDT</c> filter.</summary>
    public bool? IncludeMetaESDT { get; init; }

}
