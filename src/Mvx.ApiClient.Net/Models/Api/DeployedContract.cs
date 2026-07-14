#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the DeployedContract response returned by the MultiversX API.</summary>
public sealed class DeployedContract
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>deployTxHash</c> value.</summary>
    [JsonPropertyName("deployTxHash")]
    public string? DeployTxHash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public AccountAssets? Assets { get; init; }

}
