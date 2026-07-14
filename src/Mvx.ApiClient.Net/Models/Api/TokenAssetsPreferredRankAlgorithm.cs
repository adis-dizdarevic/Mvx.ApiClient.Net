#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TokenAssets.PreferredRankAlgorithm"/>.</summary>
public enum TokenAssetsPreferredRankAlgorithm
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>trait</c> value.</summary>
    [EnumMember(Value = "trait")]
    Trait = 1,
    /// <summary>The upstream <c>statistical</c> value.</summary>
    [EnumMember(Value = "statistical")]
    Statistical = 2,
    /// <summary>The upstream <c>openRarity</c> value.</summary>
    [EnumMember(Value = "openRarity")]
    OpenRarity = 3,
    /// <summary>The upstream <c>jaccardDistances</c> value.</summary>
    [EnumMember(Value = "jaccardDistances")]
    JaccardDistances = 4,
    /// <summary>The upstream <c>custom</c> value.</summary>
    [EnumMember(Value = "custom")]
    Custom = 5,
}
