#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the MexFarm response returned by the MultiversX API.</summary>
public sealed class MexFarm
{
    /// <summary>Gets the upstream <c>type</c> value.</summary>
    [JsonPropertyName("type")]
    public MexFarmType? Type { get; init; }

    /// <summary>Gets the upstream <c>version</c> value.</summary>
    [JsonPropertyName("version")]
    public string? Version { get; init; }

    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>id</c> value.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>Gets the upstream <c>symbol</c> value.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; init; }

    /// <summary>Gets the upstream <c>name</c> value.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Gets the upstream <c>price</c> value.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>Gets the upstream <c>farmingId</c> value.</summary>
    [JsonPropertyName("farmingId")]
    public string? FarmingId { get; init; }

    /// <summary>Gets the upstream <c>farmingSymbol</c> value.</summary>
    [JsonPropertyName("farmingSymbol")]
    public string? FarmingSymbol { get; init; }

    /// <summary>Gets the upstream <c>farmingName</c> value.</summary>
    [JsonPropertyName("farmingName")]
    public string? FarmingName { get; init; }

    /// <summary>Gets the upstream <c>farmingPrice</c> value.</summary>
    [JsonPropertyName("farmingPrice")]
    public decimal? FarmingPrice { get; init; }

    /// <summary>Gets the upstream <c>farmedId</c> value.</summary>
    [JsonPropertyName("farmedId")]
    public string? FarmedId { get; init; }

    /// <summary>Gets the upstream <c>farmedSymbol</c> value.</summary>
    [JsonPropertyName("farmedSymbol")]
    public string? FarmedSymbol { get; init; }

    /// <summary>Gets the upstream <c>farmedName</c> value.</summary>
    [JsonPropertyName("farmedName")]
    public string? FarmedName { get; init; }

    /// <summary>Gets the upstream <c>farmedPrice</c> value.</summary>
    [JsonPropertyName("farmedPrice")]
    public decimal? FarmedPrice { get; init; }

}
