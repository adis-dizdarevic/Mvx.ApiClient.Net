#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the ProviderStake response returned by the MultiversX API.</summary>
public sealed class ProviderStake
{
    /// <summary>Gets the upstream <c>totalStaked</c> value.</summary>
    [JsonPropertyName("totalStaked")]
    public BigInteger? TotalStaked { get; init; }

    /// <summary>Gets the upstream <c>unstakedTokens</c> value.</summary>
    [JsonPropertyName("unstakedTokens")]
    public IReadOnlyList<ProviderUnstakedToken>? UnstakedTokens { get; init; }

}
