using Mvx.ApiClient.Net.Enums;

namespace Mvx.ApiClient.Net.Interfaces.Clients;

public interface IMvxApiClient
{
    NetworkType NetworkType { get; }
    
    INetworkClient Network { get; }
}
