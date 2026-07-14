#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the AccountVerificationSource response returned by the MultiversX API.</summary>
public sealed class AccountVerificationSource
{
    /// <summary>Gets the upstream <c>abi</c> value.</summary>
    [JsonPropertyName("abi")]
    public JsonElement? Abi { get; init; }

    /// <summary>Gets the upstream <c>contract</c> value.</summary>
    [JsonPropertyName("contract")]
    public JsonElement? Contract { get; init; }

}
