#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="AccountVerification.Status"/>.</summary>
public enum AccountVerificationStatus
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>success</c> value.</summary>
    [EnumMember(Value = "success")]
    Success = 1,
    /// <summary>The upstream <c>byteCodeChangedSinceLastVerification</c> value.</summary>
    [EnumMember(Value = "byteCodeChangedSinceLastVerification")]
    ByteCodeChangedSinceLastVerification = 2,
}
