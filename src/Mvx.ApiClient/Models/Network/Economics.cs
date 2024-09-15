namespace Mvx.ApiClient.Models.Network;

/// <summary>
/// General economics information
/// </summary>
/// <param name="TotalSupply"></param>
/// <param name="CirculatingSupply"></param>
/// <param name="Staked"></param>
/// <param name="Price"></param>
/// <param name="MarketCap"></param>
/// <param name="Apr"></param>
/// <param name="TopUpApr"></param>
/// <param name="BaseApr"></param>
/// <param name="TokenMarketCap"></param>
public record Economics
(
    long TotalSupply,
    long CirculatingSupply,
    long Staked,
    double Price,
    long MarketCap,
    double Apr,
    double TopUpApr,
    double BaseApr,
    long? TokenMarketCap
);