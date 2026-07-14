#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="MexPair.State"/>.</summary>
public enum MexPairState
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>active</c> value.</summary>
    [EnumMember(Value = "active")]
    Active = 1,
    /// <summary>The upstream <c>inactive</c> value.</summary>
    [EnumMember(Value = "inactive")]
    Inactive = 2,
    /// <summary>The upstream <c>paused</c> value.</summary>
    [EnumMember(Value = "paused")]
    Paused = 3,
    /// <summary>The upstream <c>partial</c> value.</summary>
    [EnumMember(Value = "partial")]
    Partial = 4,
}
