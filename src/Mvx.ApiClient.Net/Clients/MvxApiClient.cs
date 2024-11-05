using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Interfaces.Clients;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(NetworkType networkType, IMexClient mex, INetworkClient network)
    {
        Mex = mex;
        NetworkType = networkType;
        Network = network;
    }

    public NetworkType NetworkType { get; }
    
    public IMexClient Mex { get; }
    public INetworkClient Network { get; }
}
