using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Interfaces.Clients;

namespace Mvx.ApiClient.Net.Clients;

internal class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(NetworkType networkType, INetworkClient network)
    {
        NetworkType = networkType;
        Network = network;
    }

    public NetworkType NetworkType { get; }
    
    public INetworkClient Network { get; }
}
