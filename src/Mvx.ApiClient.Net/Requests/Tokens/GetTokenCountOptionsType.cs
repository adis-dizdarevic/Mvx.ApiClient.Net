#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Tokens;

/// <summary>Known values for the <c>type</c> filter on /tokens/count.</summary>
public enum GetTokenCountOptionsType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>FungibleESDT</c> value.</summary>
    [EnumMember(Value = "FungibleESDT")]
    FungibleESDT = 1,
    /// <summary>The upstream <c>NonFungibleESDT</c> value.</summary>
    [EnumMember(Value = "NonFungibleESDT")]
    NonFungibleESDT = 2,
    /// <summary>The upstream <c>SemiFungibleESDT</c> value.</summary>
    [EnumMember(Value = "SemiFungibleESDT")]
    SemiFungibleESDT = 3,
    /// <summary>The upstream <c>MetaESDT</c> value.</summary>
    [EnumMember(Value = "MetaESDT")]
    MetaESDT = 4,
}
