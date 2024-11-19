using System.Text.Json.Serialization;

namespace Mvx.ApiClient.Net.Models.Block;

public record BlockDetailedDto(
    [property: JsonPropertyName("hash")]
    string Hash,
    
    [property: JsonPropertyName("epoch")]
    int Epoch,
    
    [property: JsonPropertyName("nonce")]
    int Nonce,
    
    [property: JsonPropertyName("prevHash")]
    string PreviousHash,
    
    [property: JsonPropertyName("proposer")]
    string Proposer,
    
    [property: JsonPropertyName("proposerIdentity")]
    IdentityDto Identity,
    
    [property: JsonPropertyName("pubKeyBitmap")]
    string PublicKeyBitmap,
    
    [property: JsonPropertyName("round")]
    int Round,
    
    [property: JsonPropertyName("shard")]
    int Shard,
    
    [property: JsonPropertyName("size")]
    int Size,
    
    [property: JsonPropertyName("sizeTxs")]
    int SizeTxs,
    
    [property: JsonPropertyName("stateRootHash")]
    string StateRootHash,
    
    [property: JsonPropertyName("timestamp")]
    long Timestamp,
    
    [property: JsonPropertyName("txCount")]
    int TransactionCount,
    
    [property: JsonPropertyName("gasConsumed")]
    long GasConsumed,
    
    [property: JsonPropertyName("gasRefunded")]
    long GasRefunded,
    
    [property: JsonPropertyName("gasPenalized")]
    long GasPenalized,
    
    [property: JsonPropertyName("maxGasLimit")]
    long MaxGasLimit,
    
    [property: JsonPropertyName("scheduledRootHash")]
    string ScheduledRootHash,
    
    [property: JsonPropertyName("miniBlocksHashes")]
    IEnumerable<string> MiniBlocksHashes,
    
    [property: JsonPropertyName("notarizedBlocksHashes")]
    IEnumerable<string> NotarizedBlocksHashes,
    
    [property: JsonPropertyName("validators")]
    IEnumerable<string> Validators
);
