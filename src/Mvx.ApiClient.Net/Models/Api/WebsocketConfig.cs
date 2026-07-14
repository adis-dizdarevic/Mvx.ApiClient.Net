#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the WebsocketConfig response returned by the MultiversX API.</summary>
public sealed class WebsocketConfig
{
    /// <summary>Gets the upstream <c>url</c> value.</summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

}
