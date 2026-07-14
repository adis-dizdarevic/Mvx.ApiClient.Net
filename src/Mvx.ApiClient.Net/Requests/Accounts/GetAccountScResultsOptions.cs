#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/results.</summary>
public sealed class GetAccountScResultsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
