#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the NftSupply response returned by the MultiversX API.</summary>
public sealed class NftSupply
{
    /// <summary>Gets the upstream <c>supply</c> value.</summary>
    [JsonPropertyName("supply")]
    public BigInteger? Supply { get; init; }

}
