#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Nodes;

/// <summary>Known values for the <c>type</c> filter on /nodes.</summary>
public enum GetNodesOptionsType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>observer</c> value.</summary>
    [EnumMember(Value = "observer")]
    Observer = 1,
    /// <summary>The upstream <c>validator</c> value.</summary>
    [EnumMember(Value = "validator")]
    Validator = 2,
}
