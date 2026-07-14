#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="Node.Type"/>.</summary>
public enum NodeType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>observer</c> value.</summary>
    [EnumMember(Value = "observer")]
    Observer = 1,
    /// <summary>The upstream <c>validator</c> value.</summary>
    [EnumMember(Value = "validator")]
    Validator = 2,
}
