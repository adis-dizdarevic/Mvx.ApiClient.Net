namespace Mvx.ApiClient.Models;

public class NftRank
{
    /// <summary>
    /// The identifier of the NFT
    /// </summary>
    public string Identifier { get; } = string.Empty;

    /// <summary>
    /// The rank of the NFT
    /// </summary>
    public int Rank { get; }
}
