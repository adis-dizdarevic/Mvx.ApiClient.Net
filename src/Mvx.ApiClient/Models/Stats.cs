namespace Mvx.ApiClient.Models;

public class Stats
{
    /// <summary>
    /// The total number of accounts
    /// </summary>
    public long Accounts { get; }

    /// <summary>
    /// The total number of blocks
    /// </summary>
    public long Blocks { get; }

    /// <summary>
    /// The current epoch number
    /// </summary>
    public int Epoch { get; }

    /// <summary>
    /// The current refresh rate (in ms) of a block
    /// </summary>
    public int RefreshRate { get; }

    /// <summary>
    /// The number of rounds that have passed in the current epoch
    /// </summary>
    public int RoundsPassed { get; }

    /// <summary>
    /// The total number of rounds per epoch
    /// </summary>
    public int RoundsPerEpoch { get; }

    /// <summary>
    /// The number of shards
    /// </summary>
    public int Shards { get; }

    /// <summary>
    /// The total number of transactions
    /// </summary>
    public long Transactions { get; }

    /// <summary>
    /// The total number of smart contract results
    /// </summary>
    public long ScResults { get; }
}
