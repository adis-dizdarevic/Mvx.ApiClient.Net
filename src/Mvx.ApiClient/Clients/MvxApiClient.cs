using Mvx.ApiClient.Interfaces;
using Mvx.ApiClient.Interfaces.Clients;

namespace Mvx.ApiClient.Clients;

public class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(INetworkClient network)
    {
        Network = network;
    }

    public INetworkClient Network { get; }
}
