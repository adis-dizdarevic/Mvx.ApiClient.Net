namespace Mvx.ApiClient.Models;

public class NftMetadata
{
    /// <summary>
    /// The description of the NFT
    /// </summary>
    public string Description { get; } = string.Empty;

    /// <summary>
    /// The file type of the NFT
    /// </summary>
    public string FileType { get; } = string.Empty;

    /// <summary>
    /// The file uri of the NFT
    /// </summary>
    public string FileUri { get; } = string.Empty;

    /// <summary>
    /// The file name of the NFT
    /// </summary>
    public string FileName { get; } = string.Empty;

    /// <summary>
    /// The error, if any present
    /// </summary>
    public NftMetadataError? Error { get; } 
}
