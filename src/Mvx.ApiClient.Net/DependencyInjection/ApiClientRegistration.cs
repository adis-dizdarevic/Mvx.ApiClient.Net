using Microsoft.Extensions.DependencyInjection;
using Mvx.ApiClient.Net.Clients;

namespace Mvx.ApiClient.Net;

internal static class ApiClientRegistration
{
    internal static void Register(IServiceCollection services, Uri baseAddress, MvxApiClientOptions options)
    {
        ServiceCollectionExtensions.RegisterClient<IAccountClient, AccountClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IBlockClient, BlockClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ICollectionClient, CollectionClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IDelegationClient, DelegationClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IIdentityClient, IdentityClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IKeyClient, KeyClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IMiniblockClient, MiniblockClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<INftClient, NftClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ITagClient, TagClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<INodeClient, NodeClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IProviderClient, ProviderClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IRoundClient, RoundClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IResultClient, ResultClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IShardClient, ShardClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IStakeClient, StakeClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ITokenClient, TokenClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ITransactionClient, TransactionClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IUsernameClient, UsernameClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IWaitingListClient, WaitingListClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IHealthCheckClient, HealthCheckClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IDappConfigClient, DappConfigClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IWebsocketClient, WebsocketClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ITransferClient, TransferClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<ITransactionBatchClient, TransactionBatchClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IApplicationClient, ApplicationClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IEventClient, EventClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IMarketplaceClient, MarketplaceClient>(services, baseAddress, options);
        ServiceCollectionExtensions.RegisterClient<IPoolClient, PoolClient>(services, baseAddress, options);
    }
}
