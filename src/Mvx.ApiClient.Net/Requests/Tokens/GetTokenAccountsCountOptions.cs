#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Optional filters for /tokens/{identifier}/accounts/count.</summary>
public sealed class GetTokenAccountsCountOptions
{
    /// <summary>Gets or sets the <c>accountType</c> filter.</summary>
    public GetTokenAccountsCountOptionsAccountType? AccountType { get; init; }

}
