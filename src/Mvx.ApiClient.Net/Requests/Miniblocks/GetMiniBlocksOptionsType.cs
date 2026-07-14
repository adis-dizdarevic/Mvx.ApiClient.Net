#nullable enable
using System.Runtime.Serialization;

namespace Mvx.ApiClient.Net.Requests.Miniblocks;

/// <summary>Known values for the <c>type</c> filter on /miniblocks.</summary>
public enum GetMiniBlocksOptionsType
{
    /// <summary>No supported filter value was selected.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>SmartContractResultBlock</c> value.</summary>
    [EnumMember(Value = "SmartContractResultBlock")]
    SmartContractResultBlock = 1,
    /// <summary>The upstream <c>TxBlock</c> value.</summary>
    [EnumMember(Value = "TxBlock")]
    TxBlock = 2,
    /// <summary>The upstream <c>InvalidBlock</c> value.</summary>
    [EnumMember(Value = "InvalidBlock")]
    InvalidBlock = 3,
}
