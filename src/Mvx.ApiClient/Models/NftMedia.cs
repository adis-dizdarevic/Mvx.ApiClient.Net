namespace Mvx.ApiClient.Models;

public class NftMedia
{
    /// <summary>
    /// The current url of the NFT
    /// </summary>
    public string Url { get; } = string.Empty;

    /// <summary>
    /// The original url of the NFT
    /// </summary>
    public string OriginalUrl { get; } = string.Empty;

    /// <summary>
    /// The thumbnail url of the NFT
    /// </summary>
    public string ThumbnailUrl { get; } = string.Empty;

    /// <summary>
    /// The file type
    /// </summary>
    public string FileType { get; } = string.Empty;

    /// <summary>
    /// The file size
    /// </summary>
    public int FileSize { get; }
}
