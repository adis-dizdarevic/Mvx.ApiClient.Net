#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftMedia response returned by the MultiversX API.</summary>
public sealed class NftMedia
{
    /// <summary>Gets the upstream <c>url</c> value.</summary>
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    /// <summary>Gets the upstream <c>originalUrl</c> value.</summary>
    [JsonPropertyName("originalUrl")]
    public string? OriginalUrl { get; init; }

    /// <summary>Gets the upstream <c>thumbnailUrl</c> value.</summary>
    [JsonPropertyName("thumbnailUrl")]
    public string? ThumbnailUrl { get; init; }

    /// <summary>Gets the upstream <c>fileType</c> value.</summary>
    [JsonPropertyName("fileType")]
    public string? FileType { get; init; }

    /// <summary>Gets the upstream <c>fileSize</c> value.</summary>
    [JsonPropertyName("fileSize")]
    public long? FileSize { get; init; }

}
