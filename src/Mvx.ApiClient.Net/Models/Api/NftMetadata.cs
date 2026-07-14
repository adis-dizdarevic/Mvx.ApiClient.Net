#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftMetadata response returned by the MultiversX API.</summary>
public sealed class NftMetadata
{
    /// <summary>Gets the upstream <c>description</c> value.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Gets the upstream <c>fileType</c> value.</summary>
    [JsonPropertyName("fileType")]
    public string? FileType { get; init; }

    /// <summary>Gets the upstream <c>fileUri</c> value.</summary>
    [JsonPropertyName("fileUri")]
    public string? FileUri { get; init; }

    /// <summary>Gets the upstream <c>fileName</c> value.</summary>
    [JsonPropertyName("fileName")]
    public string? FileName { get; init; }

    /// <summary>Gets the upstream <c>error</c> value.</summary>
    [JsonPropertyName("error")]
    public NftMetadataError? Error { get; init; }

}
