#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/keys.</summary>
public sealed class GetAccountKeysOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

    /// <summary>Gets or sets the <c>status</c> filter.</summary>
    public IReadOnlyCollection<string>? Status { get; init; }

}
