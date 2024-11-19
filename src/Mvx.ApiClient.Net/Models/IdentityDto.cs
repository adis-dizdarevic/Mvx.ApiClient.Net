using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models;

public record IdentityDto(
    [property: JsonPropertyName("identity")]
    string Identity,
    
    [property: JsonPropertyName("name")]
    string Name,
    
    [property: JsonPropertyName("description")]
    string Description,
    
    [property: JsonPropertyName("avatar")]
    string Avatar,
    
    [property: JsonPropertyName("website")]
    string Website,
    
    [property: JsonPropertyName("twitter")]
    string Twitter,
    
    [property: JsonPropertyName("location")]
    string Location,
    
    [property: JsonPropertyName("score")]
    double Score,
    
    [property: JsonPropertyName("validators")]
    int Validators,
    
    [property: JsonPropertyName("stake")]
    long Stake,
    
    [property: JsonPropertyName("topup")]
    long TopUp,
    
    [property: JsonPropertyName("locked")]
    long Locked,
    
    [property: JsonPropertyName("distribution")]
    IDictionary<string, long> Distribution,
    
    [property: JsonPropertyName("providers")]
    IEnumerable<string> Providers,
    
    [property: JsonPropertyName("stakepercent")]
    double StakePercent,
    
    [property: JsonPropertyName("apr")]
    double Apr,
    
    [property: JsonPropertyName("rank")]
    int Rank
);
