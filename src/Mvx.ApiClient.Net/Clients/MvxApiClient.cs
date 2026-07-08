namespace Mvx.ApiClient.Net.Clients;

internal sealed class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(NetworkType networkType, IXExchangeClient xExchange, INetworkClient network)
    {
        XExchange = xExchange;
        NetworkType = networkType;
        Network = network;
    }

    public NetworkType NetworkType { get; }

    public IXExchangeClient XExchange { get; }

    public INetworkClient Network { get; }
}
