#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the UnlockMilestone response returned by the MultiversX API.</summary>
public sealed class UnlockMilestone
{
    /// <summary>Gets the upstream <c>remainingEpochs</c> value.</summary>
    [JsonPropertyName("remainingEpochs")]
    public long? RemainingEpochs { get; init; }

    /// <summary>Gets the upstream <c>percent</c> value.</summary>
    [JsonPropertyName("percent")]
    public decimal? Percent { get; init; }

}
