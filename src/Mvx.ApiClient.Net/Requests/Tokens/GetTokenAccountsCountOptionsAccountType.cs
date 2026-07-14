#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Known values for the <c>accountType</c> filter on /tokens/{identifier}/accounts/count.</summary>
public enum GetTokenAccountsCountOptionsAccountType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>smartcontract</c> value.</summary>
    [EnumMember(Value = "smartcontract")]
    Smartcontract = 1,
    /// <summary>The upstream <c>wallet</c> value.</summary>
    [EnumMember(Value = "wallet")]
    Wallet = 2,
}
