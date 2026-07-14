#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the EsdtSupply response returned by the MultiversX API.</summary>
public sealed class EsdtSupply
{
    /// <summary>Gets the upstream <c>totalSupply</c> value.</summary>
    [JsonPropertyName("totalSupply")]
    public BigInteger? TotalSupply { get; init; }

    /// <summary>Gets the upstream <c>circulatingSupply</c> value.</summary>
    [JsonPropertyName("circulatingSupply")]
    public BigInteger? CirculatingSupply { get; init; }

    /// <summary>Gets the upstream <c>minted</c> value.</summary>
    [JsonPropertyName("minted")]
    public BigInteger? Minted { get; init; }

    /// <summary>Gets the upstream <c>burned</c> value.</summary>
    [JsonPropertyName("burned")]
    public BigInteger? Burned { get; init; }

    /// <summary>Gets the upstream <c>initialMinted</c> value.</summary>
    [JsonPropertyName("initialMinted")]
    public BigInteger? InitialMinted { get; init; }

    /// <summary>Gets the upstream <c>lockedAccounts</c> value.</summary>
    [JsonPropertyName("lockedAccounts")]
    public JsonElement? LockedAccounts { get; init; }

}
