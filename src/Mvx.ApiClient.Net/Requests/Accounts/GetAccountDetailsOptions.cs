#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Optional filters for /accounts/{address}.</summary>
public sealed class GetAccountDetailsOptions
{
    /// <summary>Gets or sets the <c>withGuardianInfo</c> filter.</summary>
    public bool? WithGuardianInfo { get; init; }

    /// <summary>Gets or sets the <c>withTxCount</c> filter.</summary>
    public bool? WithTxCount { get; init; }

    /// <summary>Gets or sets the <c>withScrCount</c> filter.</summary>
    public bool? WithScrCount { get; init; }

    /// <summary>Gets or sets the <c>withTimestamp</c> filter.</summary>
    public bool? WithTimestamp { get; init; }

    /// <summary>Gets or sets the <c>withAssets</c> filter.</summary>
    public bool? WithAssets { get; init; }

    /// <summary>Gets or sets the <c>timestamp</c> filter.</summary>
    public long? Timestamp { get; init; }

}
