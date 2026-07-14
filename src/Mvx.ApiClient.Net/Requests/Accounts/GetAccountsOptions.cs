#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts.</summary>
public sealed class GetAccountsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>ownerAddress</c> filter.</summary>
    public string? OwnerAddress { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>tags</c> filter.</summary>
    public IReadOnlyCollection<string>? Tags { get; init; }

    /// <summary>Gets or sets the <c>sort</c> filter.</summary>
    public GetAccountsOptionsSort? Sort { get; init; }

    /// <summary>Gets or sets the <c>order</c> filter.</summary>
    public GetAccountsOptionsOrder? Order { get; init; }

    /// <summary>Gets or sets the <c>isSmartContract</c> filter.</summary>
    public bool? IsSmartContract { get; init; }

    /// <summary>Gets or sets the <c>withOwnerAssets</c> filter.</summary>
    public bool? WithOwnerAssets { get; init; }

    /// <summary>Gets or sets the <c>withDeployInfo</c> filter.</summary>
    public bool? WithDeployInfo { get; init; }

    /// <summary>Gets or sets the <c>withTxCount</c> filter.</summary>
    public bool? WithTxCount { get; init; }

    /// <summary>Gets or sets the <c>withScrCount</c> filter.</summary>
    public bool? WithScrCount { get; init; }

    /// <summary>Gets or sets the <c>excludeTags</c> filter.</summary>
    public IReadOnlyCollection<string>? ExcludeTags { get; init; }

    /// <summary>Gets or sets the <c>hasAssets</c> filter.</summary>
    public bool? HasAssets { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>addresses</c> filter.</summary>
    public string? Addresses { get; init; }

}
