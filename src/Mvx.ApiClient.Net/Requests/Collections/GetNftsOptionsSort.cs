#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Collections;

/// <summary>Known values for the <c>sort</c> filter on /collections/{collection}/nfts.</summary>
public enum GetNftsOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>timestamp</c> value.</summary>
    [EnumMember(Value = "timestamp")]
    Timestamp = 1,
    /// <summary>The upstream <c>rank</c> value.</summary>
    [EnumMember(Value = "rank")]
    Rank = 2,
    /// <summary>The upstream <c>nonce</c> value.</summary>
    [EnumMember(Value = "nonce")]
    Nonce = 3,
}
