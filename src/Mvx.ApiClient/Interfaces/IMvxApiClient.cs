using Mvx.ApiClient.Interfaces.Clients;

namespace Mvx.ApiClient.Interfaces;

public interface IMvxApiClient
{
    INetworkClient Network { get; }
}
