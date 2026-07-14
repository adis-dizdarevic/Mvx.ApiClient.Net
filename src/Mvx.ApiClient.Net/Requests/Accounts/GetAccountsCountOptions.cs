#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/count.</summary>
public sealed class GetAccountsCountOptions
{
    /// <summary>Gets or sets the <c>ownerAddress</c> filter.</summary>
    public string? OwnerAddress { get; init; }

    /// <summary>Gets or sets the <c>isSmartContract</c> filter.</summary>
    public bool? IsSmartContract { get; init; }

    /// <summary>Gets or sets the <c>name</c> filter.</summary>
    public string? Name { get; init; }

    /// <summary>Gets or sets the <c>tags</c> filter.</summary>
    public IReadOnlyCollection<string>? Tags { get; init; }

    /// <summary>Gets or sets the <c>excludeTags</c> filter.</summary>
    public IReadOnlyCollection<string>? ExcludeTags { get; init; }

    /// <summary>Gets or sets the <c>hasAssets</c> filter.</summary>
    public bool? HasAssets { get; init; }

    /// <summary>Gets or sets the <c>search</c> filter.</summary>
    public string? Search { get; init; }

    /// <summary>Gets or sets the <c>withBalance</c> filter.</summary>
    public bool? WithBalance { get; init; }

}
