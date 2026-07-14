using System.Numerics;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>
/// Represents an account delegated to a staking provider.
/// </summary>
public sealed class ProviderAccount
{
    /// <summary>Gets the delegator address.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the atomic amount delegated by the account.</summary>
    [JsonPropertyName("stake")]
    public BigInteger? Stake { get; init; }
}
