#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TransactionOperation.Action"/>.</summary>
public enum TransactionOperationAction
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>none</c> value.</summary>
    [EnumMember(Value = "none")]
    None = 1,
    /// <summary>The upstream <c>transfer</c> value.</summary>
    [EnumMember(Value = "transfer")]
    Transfer = 2,
    /// <summary>The upstream <c>transferValueOnly</c> value.</summary>
    [EnumMember(Value = "transferValueOnly")]
    TransferValueOnly = 3,
    /// <summary>The upstream <c>burn</c> value.</summary>
    [EnumMember(Value = "burn")]
    Burn = 4,
    /// <summary>The upstream <c>addQuantity</c> value.</summary>
    [EnumMember(Value = "addQuantity")]
    AddQuantity = 5,
    /// <summary>The upstream <c>create</c> value.</summary>
    [EnumMember(Value = "create")]
    Create = 6,
    /// <summary>The upstream <c>localMint</c> value.</summary>
    [EnumMember(Value = "localMint")]
    LocalMint = 7,
    /// <summary>The upstream <c>localBurn</c> value.</summary>
    [EnumMember(Value = "localBurn")]
    LocalBurn = 8,
    /// <summary>The upstream <c>wipe</c> value.</summary>
    [EnumMember(Value = "wipe")]
    Wipe = 9,
    /// <summary>The upstream <c>freeze</c> value.</summary>
    [EnumMember(Value = "freeze")]
    Freeze = 10,
    /// <summary>The upstream <c>writeLog</c> value.</summary>
    [EnumMember(Value = "writeLog")]
    WriteLog = 11,
    /// <summary>The upstream <c>signalError</c> value.</summary>
    [EnumMember(Value = "signalError")]
    SignalError = 12,
}
