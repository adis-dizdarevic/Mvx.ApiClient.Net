namespace Mvx.ApiClient.Net;

internal static class EndpointPaths
{
    internal const string XExchangeEconomics = "/mex/economics";
    internal const string XExchangePairs = "/mex/pairs";
    internal const string XExchangePairsCount = "/mex/pairs/count";
    internal const string XExchangePairDetails = "/mex/pairs/{0}/{1}";
    internal const string XExchangeTokens = "/mex/tokens";
    internal const string XExchangeTokensCount = "/mex/tokens/count";
    internal const string XExchangeTokenDetails = "/mex/tokens/{0}";
    internal const string XExchangeFarms = "/mex/farms";
    internal const string XExchangeFarmsCount = "/mex/farms/count";

    internal const string NetworkStats = "/stats";
    internal const string NetworkEconomics = "/economics";
    internal const string NetworkConstants = "/constants";
    internal const string NetworkAbout = "/about";
}
