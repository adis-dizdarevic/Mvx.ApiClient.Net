#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Known values for the <c>sort</c> filter on /collections.</summary>
public enum GetNftCollectionsOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>timestamp</c> value.</summary>
    [EnumMember(Value = "timestamp")]
    Timestamp = 1,
    /// <summary>The upstream <c>verifiedAndHolderCount</c> value.</summary>
    [EnumMember(Value = "verifiedAndHolderCount")]
    VerifiedAndHolderCount = 2,
}
