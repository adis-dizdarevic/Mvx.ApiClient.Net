#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nodes;

/// <summary>Known values for the <c>sort</c> filter on /nodes/auctions.</summary>
public enum GetNodesAuctionsOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>auctionValidators</c> value.</summary>
    [EnumMember(Value = "auctionValidators")]
    AuctionValidators = 1,
    /// <summary>The upstream <c>droppedValidators</c> value.</summary>
    [EnumMember(Value = "droppedValidators")]
    DroppedValidators = 2,
    /// <summary>The upstream <c>qualifiedAuctionValidators</c> value.</summary>
    [EnumMember(Value = "qualifiedAuctionValidators")]
    QualifiedAuctionValidators = 3,
    /// <summary>The upstream <c>qualifiedStake</c> value.</summary>
    [EnumMember(Value = "qualifiedStake")]
    QualifiedStake = 4,
    /// <summary>The upstream <c>dangerZoneValidators</c> value.</summary>
    [EnumMember(Value = "dangerZoneValidators")]
    DangerZoneValidators = 5,
}
