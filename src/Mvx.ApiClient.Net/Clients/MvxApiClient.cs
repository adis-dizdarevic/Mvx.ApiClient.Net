namespace Mvx.ApiClient.Net.Clients;

internal sealed partial class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(NetworkType networkType, IXExchangeClient xExchange, INetworkClient network, IServiceProvider serviceProvider)
    {
        XExchange = xExchange;
        NetworkType = networkType;
        Network = network;
        InitializeGeneratedClients(serviceProvider);
    }

    public NetworkType NetworkType { get; }

    public IXExchangeClient XExchange { get; }

    public INetworkClient Network { get; }
}
