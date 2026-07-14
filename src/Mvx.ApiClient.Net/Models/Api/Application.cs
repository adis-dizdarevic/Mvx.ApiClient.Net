#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the Application response returned by the MultiversX API.</summary>
public sealed class Application
{
    /// <summary>Gets the upstream <c>contract</c> value.</summary>
    [JsonPropertyName("contract")]
    public string? Contract { get; init; }

    /// <summary>Gets the upstream <c>deployer</c> value.</summary>
    [JsonPropertyName("deployer")]
    public string? Deployer { get; init; }

    /// <summary>Gets the upstream <c>owner</c> value.</summary>
    [JsonPropertyName("owner")]
    public string? Owner { get; init; }

    /// <summary>Gets the upstream <c>codeHash</c> value.</summary>
    [JsonPropertyName("codeHash")]
    public string? CodeHash { get; init; }

    /// <summary>Gets the upstream <c>timestamp</c> value.</summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; init; }

    /// <summary>Gets the upstream <c>assets</c> value.</summary>
    [JsonPropertyName("assets")]
    public AccountAssets? Assets { get; init; }

    /// <summary>Gets the upstream <c>balance</c> value.</summary>
    [JsonPropertyName("balance")]
    public BigInteger? Balance { get; init; }

    /// <summary>Gets the upstream <c>txCount</c> value.</summary>
    [JsonPropertyName("txCount")]
    public long? TxCount { get; init; }

}
