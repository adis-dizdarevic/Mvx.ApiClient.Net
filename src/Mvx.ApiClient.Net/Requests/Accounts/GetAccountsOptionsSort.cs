#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Known values for the <c>sort</c> filter on /accounts.</summary>
public enum GetAccountsOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>balance</c> value.</summary>
    [EnumMember(Value = "balance")]
    Balance = 1,
    /// <summary>The upstream <c>timestamp</c> value.</summary>
    [EnumMember(Value = "timestamp")]
    Timestamp = 2,
    /// <summary>The upstream <c>transfersLast24h</c> value.</summary>
    [EnumMember(Value = "transfersLast24h")]
    TransfersLast24H = 3,
}
