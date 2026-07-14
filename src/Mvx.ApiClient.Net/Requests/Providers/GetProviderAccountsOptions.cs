#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Providers;

/// <summary>Optional filters for /providers/{address}/accounts.</summary>
public sealed class GetProviderAccountsOptions
{
    /// <summary>Gets or sets pagination for the request.</summary>
    public Pagination? Pagination { get; init; }

}
