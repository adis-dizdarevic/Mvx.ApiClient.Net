#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="Auction.Status"/>.</summary>
public enum AuctionStatus
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>running</c> value.</summary>
    [EnumMember(Value = "running")]
    Running = 1,
    /// <summary>The upstream <c>claimable</c> value.</summary>
    [EnumMember(Value = "claimable")]
    Claimable = 2,
    /// <summary>The upstream <c>ended</c> value.</summary>
    [EnumMember(Value = "ended")]
    Ended = 3,
    /// <summary>The upstream <c>closed</c> value.</summary>
    [EnumMember(Value = "closed")]
    Closed = 4,
    /// <summary>The upstream <c>unknown</c> value.</summary>
    [EnumMember(Value = "unknown")]
    UpstreamUnknown = 5,
}
