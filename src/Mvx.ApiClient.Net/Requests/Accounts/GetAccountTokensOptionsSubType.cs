#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Accounts;

/// <summary>Known values for the <c>subType</c> filter on /accounts/{address}/tokens.</summary>
public enum GetAccountTokensOptionsSubType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>NonFungibleESDT</c> value.</summary>
    [EnumMember(Value = "NonFungibleESDT")]
    NonFungibleESDT = 1,
    /// <summary>The upstream <c>SemiFungibleESDT</c> value.</summary>
    [EnumMember(Value = "SemiFungibleESDT")]
    SemiFungibleESDT = 2,
    /// <summary>The upstream <c>MetaESDT</c> value.</summary>
    [EnumMember(Value = "MetaESDT")]
    MetaESDT = 3,
    /// <summary>The upstream <c>NonFungibleESDTv2</c> value.</summary>
    [EnumMember(Value = "NonFungibleESDTv2")]
    NonFungibleESDTv2 = 4,
    /// <summary>The upstream <c>DynamicNonFungibleESDT</c> value.</summary>
    [EnumMember(Value = "DynamicNonFungibleESDT")]
    DynamicNonFungibleESDT = 5,
    /// <summary>The upstream <c>DynamicSemiFungibleESDT</c> value.</summary>
    [EnumMember(Value = "DynamicSemiFungibleESDT")]
    DynamicSemiFungibleESDT = 6,
    /// <summary>The upstream <c>DynamicMetaESDT</c> value.</summary>
    [EnumMember(Value = "DynamicMetaESDT")]
    DynamicMetaESDT = 7,
    /// <summary>The upstream <c>(empty)</c> value.</summary>
    [EnumMember(Value = "")]
    Empty = 8,
}
