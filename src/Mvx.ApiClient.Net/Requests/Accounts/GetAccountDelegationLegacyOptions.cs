#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}/delegation-legacy.</summary>
public sealed class GetAccountDelegationLegacyOptions
{
    /// <summary>Gets or sets the <c>timestamp</c> filter.</summary>
    public long? Timestamp { get; init; }

}
