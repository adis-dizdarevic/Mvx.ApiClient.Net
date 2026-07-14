#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="Transaction.Type"/>.</summary>
public enum TransactionType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>Transaction</c> value.</summary>
    [EnumMember(Value = "Transaction")]
    Transaction = 1,
    /// <summary>The upstream <c>SmartContractResult</c> value.</summary>
    [EnumMember(Value = "SmartContractResult")]
    SmartContractResult = 2,
    /// <summary>The upstream <c>Reward</c> value.</summary>
    [EnumMember(Value = "Reward")]
    Reward = 3,
}
