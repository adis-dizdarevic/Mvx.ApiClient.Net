#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nodes;

/// <summary>Known values for the <c>sort</c> filter on /nodes.</summary>
public enum GetNodesOptionsSort
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>name</c> value.</summary>
    [EnumMember(Value = "name")]
    Name = 1,
    /// <summary>The upstream <c>version</c> value.</summary>
    [EnumMember(Value = "version")]
    Version = 2,
    /// <summary>The upstream <c>tempRating</c> value.</summary>
    [EnumMember(Value = "tempRating")]
    TempRating = 3,
    /// <summary>The upstream <c>leaderSuccess</c> value.</summary>
    [EnumMember(Value = "leaderSuccess")]
    LeaderSuccess = 4,
    /// <summary>The upstream <c>leaderFailure</c> value.</summary>
    [EnumMember(Value = "leaderFailure")]
    LeaderFailure = 5,
    /// <summary>The upstream <c>validatorSuccess</c> value.</summary>
    [EnumMember(Value = "validatorSuccess")]
    ValidatorSuccess = 6,
    /// <summary>The upstream <c>validatorFailure</c> value.</summary>
    [EnumMember(Value = "validatorFailure")]
    ValidatorFailure = 7,
    /// <summary>The upstream <c>validatorIgnoredSignatures</c> value.</summary>
    [EnumMember(Value = "validatorIgnoredSignatures")]
    ValidatorIgnoredSignatures = 8,
    /// <summary>The upstream <c>position</c> value.</summary>
    [EnumMember(Value = "position")]
    Position = 9,
}
