#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountVerification response returned by the MultiversX API.</summary>
public sealed class AccountVerification
{
    /// <summary>Gets the upstream <c>codeHash</c> value.</summary>
    [JsonPropertyName("codeHash")]
    public string? CodeHash { get; init; }

    /// <summary>Gets the upstream <c>source</c> value.</summary>
    [JsonPropertyName("source")]
    public AccountVerificationSource? Source { get; init; }

    /// <summary>Gets the upstream <c>status</c> value.</summary>
    [JsonPropertyName("status")]
    public AccountVerificationStatus? Status { get; init; }

    /// <summary>Gets the upstream <c>ipfsFileHash</c> value.</summary>
    [JsonPropertyName("ipfsFileHash")]
    public string? IpfsFileHash { get; init; }

}
