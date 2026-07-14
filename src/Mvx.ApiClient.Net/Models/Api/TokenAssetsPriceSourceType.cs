#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="TokenAssetsPriceSource.Type"/>.</summary>
public enum TokenAssetsPriceSourceType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>dataApi</c> value.</summary>
    [EnumMember(Value = "dataApi")]
    DataApi = 1,
    /// <summary>The upstream <c>customUrl</c> value.</summary>
    [EnumMember(Value = "customUrl")]
    CustomUrl = 2,
}
