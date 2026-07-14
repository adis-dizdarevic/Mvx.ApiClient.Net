#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Known values for the <c>type</c> filter on /accounts/{address}/tokens/count.</summary>
public enum GetTokenCountOptionsType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>FungibleESDT</c> value.</summary>
    [EnumMember(Value = "FungibleESDT")]
    FungibleESDT = 1,
    /// <summary>The upstream <c>MetaESDT</c> value.</summary>
    [EnumMember(Value = "MetaESDT")]
    MetaESDT = 2,
}
