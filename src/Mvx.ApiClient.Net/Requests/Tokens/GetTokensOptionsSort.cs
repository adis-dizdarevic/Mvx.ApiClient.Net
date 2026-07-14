#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Known values for the <c>sort</c> filter on /tokens.</summary>
public enum GetTokensOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>accounts</c> value.</summary>
    [EnumMember(Value = "accounts")]
    Accounts = 1,
    /// <summary>The upstream <c>transactions</c> value.</summary>
    [EnumMember(Value = "transactions")]
    Transactions = 2,
    /// <summary>The upstream <c>price</c> value.</summary>
    [EnumMember(Value = "price")]
    Price = 3,
    /// <summary>The upstream <c>marketCap</c> value.</summary>
    [EnumMember(Value = "marketCap")]
    MarketCap = 4,
}
