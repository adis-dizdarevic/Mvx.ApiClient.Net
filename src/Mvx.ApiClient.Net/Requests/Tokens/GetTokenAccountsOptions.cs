#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens/{identifier}/accounts.</summary>
public sealed class GetTokenAccountsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>accountType</c> filter.</summary>
    public GetTokenAccountsOptionsAccountType? AccountType { get; init; }

}
