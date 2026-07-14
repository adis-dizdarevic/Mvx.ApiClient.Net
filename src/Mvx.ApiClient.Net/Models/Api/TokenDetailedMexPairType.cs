#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TokenDetailed.MexPairType"/>.</summary>
public enum TokenDetailedMexPairType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>core</c> value.</summary>
    [EnumMember(Value = "core")]
    Core = 1,
    /// <summary>The upstream <c>community</c> value.</summary>
    [EnumMember(Value = "community")]
    Community = 2,
    /// <summary>The upstream <c>ecosystem</c> value.</summary>
    [EnumMember(Value = "ecosystem")]
    Ecosystem = 3,
    /// <summary>The upstream <c>experimental</c> value.</summary>
    [EnumMember(Value = "experimental")]
    Experimental = 4,
    /// <summary>The upstream <c>unlisted</c> value.</summary>
    [EnumMember(Value = "unlisted")]
    Unlisted = 5,
}
