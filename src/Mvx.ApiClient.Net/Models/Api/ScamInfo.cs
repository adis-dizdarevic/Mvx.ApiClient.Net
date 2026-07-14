#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the ScamInfo response returned by the MultiversX API.</summary>
public sealed class ScamInfo
{
    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>Gets the upstream <c>info</c> value.</summary>
    [JsonPropertyName("info")]
    public string? Info { get; init; }

}
