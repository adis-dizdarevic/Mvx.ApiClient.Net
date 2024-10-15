namespace Mvx.ApiClient.Models.Network;

/// <summary>
/// General network statistics
/// </summary>
/// <param name="Accounts">The total number of accounts</param>
/// <param name="Blocks">The total number of blocks</param>
/// <param name="Epoch">The current epoch number</param>
/// <param name="RefreshRate">The current refresh rate (in ms) of a block</param>
/// <param name="RoundsPassed">The number of rounds that have passed in the current epoch</param>
/// <param name="RoundsPerEpoch">The total number of rounds per epoch</param>
/// <param name="Shards">The number of shards</param>
/// <param name="Transactions">The total number of transactions</param>
/// <param name="ScResults">The total number of smart contract results</param>
public record StatsDto(
    long Accounts,
    long Blocks,
    int Epoch,
    int RefreshRate,
    int RoundsPassed,
    int RoundsPerEpoch,
    int Shards,
    long Transactions,
    long ScResults
);
