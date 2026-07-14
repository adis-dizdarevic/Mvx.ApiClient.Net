#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TransactionOperation.Type"/>.</summary>
public enum TransactionOperationType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>none</c> value.</summary>
    [EnumMember(Value = "none")]
    None = 1,
    /// <summary>The upstream <c>nft</c> value.</summary>
    [EnumMember(Value = "nft")]
    Nft = 2,
    /// <summary>The upstream <c>esdt</c> value.</summary>
    [EnumMember(Value = "esdt")]
    Esdt = 3,
    /// <summary>The upstream <c>log</c> value.</summary>
    [EnumMember(Value = "log")]
    Log = 4,
    /// <summary>The upstream <c>error</c> value.</summary>
    [EnumMember(Value = "error")]
    Error = 5,
    /// <summary>The upstream <c>egld</c> value.</summary>
    [EnumMember(Value = "egld")]
    Egld = 6,
}
