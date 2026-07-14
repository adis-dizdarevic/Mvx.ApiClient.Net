#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountAssets response returned by the MultiversX API.</summary>
public sealed class AccountAssets
{
    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>social</c> value.</summary>
    [JsonPropertyName("social")]
    public IReadOnlyDictionary<string, string>? Social { get; init; }

    /// <summary>Gets the upstream <c>tags</c> value.</summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }

    /// <summary>Gets the upstream <c>icon</c> value.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Gets the upstream <c>iconPng</c> value.</summary>
    [JsonPropertyName("iconPng")]
    public string? IconPng { get; init; }

    /// <summary>Gets the upstream <c>iconSvg</c> value.</summary>
    [JsonPropertyName("iconSvg")]
    public string? IconSvg { get; init; }

}
