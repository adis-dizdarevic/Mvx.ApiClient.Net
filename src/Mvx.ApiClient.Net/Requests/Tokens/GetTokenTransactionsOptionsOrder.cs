#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Known values for the <c>order</c> filter on /tokens/{identifier}/transactions.</summary>
public enum GetTokenTransactionsOptionsOrder
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>asc</c> value.</summary>
    [EnumMember(Value = "asc")]
    Asc = 1,
    /// <summary>The upstream <c>desc</c> value.</summary>
    [EnumMember(Value = "desc")]
    Desc = 2,
}
