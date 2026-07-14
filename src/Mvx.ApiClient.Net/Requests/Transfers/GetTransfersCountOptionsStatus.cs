#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Transfers;

/// <summary>Known values for the <c>status</c> filter on /transfers/count.</summary>
public enum GetTransfersCountOptionsStatus
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>success</c> value.</summary>
    [EnumMember(Value = "success")]
    Success = 1,
    /// <summary>The upstream <c>pending</c> value.</summary>
    [EnumMember(Value = "pending")]
    Pending = 2,
    /// <summary>The upstream <c>invalid</c> value.</summary>
    [EnumMember(Value = "invalid")]
    Invalid = 3,
    /// <summary>The upstream <c>fail</c> value.</summary>
    [EnumMember(Value = "fail")]
    Fail = 4,
}
