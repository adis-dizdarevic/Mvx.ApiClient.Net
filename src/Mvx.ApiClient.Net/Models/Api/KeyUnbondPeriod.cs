#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the KeyUnbondPeriod response returned by the MultiversX API.</summary>
public sealed class KeyUnbondPeriod
{
    /// <summary>Gets the upstream <c>remainingUnBondPeriod</c> value.</summary>
    [JsonPropertyName("remainingUnBondPeriod")]
    public long? RemainingUnBondPeriod { get; init; }

}
