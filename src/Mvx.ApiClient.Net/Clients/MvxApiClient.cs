using Mvx.ApiClient.Net.Interfaces.Clients;

namespace Mvx.ApiClient.Net.Clients;

public class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(INetworkClient network)
    {
        Network = network;
    }

    public INetworkClient Network { get; }
}
