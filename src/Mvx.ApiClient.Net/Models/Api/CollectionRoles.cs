#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Represents the CollectionRoles response returned by the MultiversX API.</summary>
public sealed class CollectionRoles
{
    /// <summary>Gets the upstream <c>address</c> value.</summary>
    [JsonPropertyName("address")]
    public string? Address { get; init; }

    /// <summary>Gets the upstream <c>canCreate</c> value.</summary>
    [JsonPropertyName("canCreate")]
    public bool? CanCreate { get; init; }

    /// <summary>Gets the upstream <c>canBurn</c> value.</summary>
    [JsonPropertyName("canBurn")]
    public bool? CanBurn { get; init; }

    /// <summary>Gets the upstream <c>canAddQuantity</c> value.</summary>
    [JsonPropertyName("canAddQuantity")]
    public bool? CanAddQuantity { get; init; }

    /// <summary>Gets the upstream <c>canUpdateAttributes</c> value.</summary>
    [JsonPropertyName("canUpdateAttributes")]
    public bool? CanUpdateAttributes { get; init; }

    /// <summary>Gets the upstream <c>canAddUri</c> value.</summary>
    [JsonPropertyName("canAddUri")]
    public bool? CanAddUri { get; init; }

    /// <summary>Gets the upstream <c>canTransfer</c> value.</summary>
    [JsonPropertyName("canTransfer")]
    public bool? CanTransfer { get; init; }

    /// <summary>Gets the upstream <c>roles</c> value.</summary>
    [JsonPropertyName("roles")]
    public IReadOnlyList<string>? Roles { get; init; }

}
