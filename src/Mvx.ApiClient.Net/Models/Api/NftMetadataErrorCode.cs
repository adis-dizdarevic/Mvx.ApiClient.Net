#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="NftMetadataError.Code"/>.</summary>
public enum NftMetadataErrorCode
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>ipfs_error</c> value.</summary>
    [EnumMember(Value = "ipfs_error")]
    IpfsError = 1,
    /// <summary>The upstream <c>not_found</c> value.</summary>
    [EnumMember(Value = "not_found")]
    NotFound = 2,
    /// <summary>The upstream <c>timeout</c> value.</summary>
    [EnumMember(Value = "timeout")]
    Timeout = 3,
    /// <summary>The upstream <c>unknown_error</c> value.</summary>
    [EnumMember(Value = "unknown_error")]
    UnknownError = 4,
    /// <summary>The upstream <c>invalid_content_type</c> value.</summary>
    [EnumMember(Value = "invalid_content_type")]
    InvalidContentType = 5,
    /// <summary>The upstream <c>json_parse_error</c> value.</summary>
    [EnumMember(Value = "json_parse_error")]
    JsonParseError = 6,
    /// <summary>The upstream <c>empty_metadata</c> value.</summary>
    [EnumMember(Value = "empty_metadata")]
    EmptyMetadata = 7,
}
