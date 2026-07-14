#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TokenWithRoles.Type"/>.</summary>
public enum TokenWithRolesType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
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
