#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the About response returned by the MultiversX API.</summary>
public sealed class About
{
    /// <summary>Gets the upstream <c>appVersion</c> value.</summary>
    [JsonPropertyName("appVersion")]
    public string? AppVersion { get; init; }

    /// <summary>Gets the upstream <c>pluginsVersion</c> value.</summary>
    [JsonPropertyName("pluginsVersion")]
    public string? PluginsVersion { get; init; }

    /// <summary>Gets the upstream <c>network</c> value.</summary>
    [JsonPropertyName("network")]
    public string? Network { get; init; }

    /// <summary>Gets the upstream <c>cluster</c> value.</summary>
    [JsonPropertyName("cluster")]
    public string? Cluster { get; init; }

    /// <summary>Gets the upstream <c>version</c> value.</summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>Gets the upstream <c>indexerVersion</c> value.</summary>
    [JsonPropertyName("indexerVersion")]
    public string? IndexerVersion { get; init; }

    /// <summary>Gets the upstream <c>gatewayVersion</c> value.</summary>
    [JsonPropertyName("gatewayVersion")]
    public string? GatewayVersion { get; init; }

    /// <summary>Gets the upstream <c>scamEngineVersion</c> value.</summary>
    [JsonPropertyName("scamEngineVersion")]
    public string? ScamEngineVersion { get; init; }

    /// <summary>Gets the upstream <c>features</c> value.</summary>
    [JsonPropertyName("features")]
    public FeatureConfigs? Features { get; init; }

}
