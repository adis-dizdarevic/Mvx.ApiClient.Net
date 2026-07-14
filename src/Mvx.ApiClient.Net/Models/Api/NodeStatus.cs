#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="Node.Status"/>.</summary>
public enum NodeStatus
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>new</c> value.</summary>
    [EnumMember(Value = "new")]
    New = 1,
    /// <summary>The upstream <c>unknown</c> value.</summary>
    [EnumMember(Value = "unknown")]
    UpstreamUnknown = 2,
    /// <summary>The upstream <c>waiting</c> value.</summary>
    [EnumMember(Value = "waiting")]
    Waiting = 3,
    /// <summary>The upstream <c>eligible</c> value.</summary>
    [EnumMember(Value = "eligible")]
    Eligible = 4,
    /// <summary>The upstream <c>jailed</c> value.</summary>
    [EnumMember(Value = "jailed")]
    Jailed = 5,
    /// <summary>The upstream <c>queued</c> value.</summary>
    [EnumMember(Value = "queued")]
    Queued = 6,
    /// <summary>The upstream <c>leaving</c> value.</summary>
    [EnumMember(Value = "leaving")]
    Leaving = 7,
    /// <summary>The upstream <c>inactive</c> value.</summary>
    [EnumMember(Value = "inactive")]
    Inactive = 8,
    /// <summary>The upstream <c>auction</c> value.</summary>
    [EnumMember(Value = "auction")]
    Auction = 9,
}
