#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/history/count.</summary>
public sealed class GetAccountHistoryCountOptions
{
    /// <summary>Gets or sets the <c>before</c> filter.</summary>
    public long? Before { get; init; }

    /// <summary>Gets or sets the <c>after</c> filter.</summary>
    public long? After { get; init; }

}
