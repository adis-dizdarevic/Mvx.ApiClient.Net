namespace Mvx.ApiClient.Net.Models.Network;

/// <summary>
/// General economics information
/// </summary>
/// <param name="TotalSupply">The current total supply</param>
/// <param name="CirculatingSupply">The current circulating supply</param>
/// <param name="Staked">The currently staked EGLD</param>
/// <param name="Price">The current EGLD price</param>
/// <param name="MarketCap">The current EGLD marketcap</param>
/// <param name="Apr">The current apr of EGLD</param>
/// <param name="TopUpApr">The current topup apr of EGLD</param>
/// <param name="BaseApr">The current base apr of EGLD</param>
/// <param name="TokenMarketCap">The current token marketcap</param>
public sealed record EconomicsDto
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
