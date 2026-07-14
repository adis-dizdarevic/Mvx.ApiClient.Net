#nullable enable
using System.Numerics;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Api;

/// <summary>Known values for <see cref="MexFarm.Type"/>.</summary>
public enum MexFarmType
{
    /// <summary>The API returned a value unknown to this package version.</summary>
    Unknown = 0,
    /// <summary>The upstream <c>standard</c> value.</summary>
    [EnumMember(Value = "standard")]
    Standard = 1,
    /// <summary>The upstream <c>metastaking</c> value.</summary>
    [EnumMember(Value = "metastaking")]
    Metastaking = 2,
}
