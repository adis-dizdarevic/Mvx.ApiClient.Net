using Microsoft.Extensions.DependencyInjection;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class MvxApiClient : IMvxApiClient
{
    public MvxApiClient(NetworkType networkType, IXExchangeClient xExchange, INetworkClient network, IServiceProvider serviceProvider)
    {
        XExchange = xExchange;
        NetworkType = networkType;
        Network = network;
        Accounts = serviceProvider.GetRequiredService<IAccountClient>();
        Blocks = serviceProvider.GetRequiredService<IBlockClient>();
        Collections = serviceProvider.GetRequiredService<ICollectionClient>();
        Delegation = serviceProvider.GetRequiredService<IDelegationClient>();
        Identities = serviceProvider.GetRequiredService<IIdentityClient>();
        Keys = serviceProvider.GetRequiredService<IKeyClient>();
        Miniblocks = serviceProvider.GetRequiredService<IMiniblockClient>();
        Nfts = serviceProvider.GetRequiredService<INftClient>();
        Tags = serviceProvider.GetRequiredService<ITagClient>();
        Nodes = serviceProvider.GetRequiredService<INodeClient>();
        Providers = serviceProvider.GetRequiredService<IProviderClient>();
        Rounds = serviceProvider.GetRequiredService<IRoundClient>();
        Results = serviceProvider.GetRequiredService<IResultClient>();
        Shards = serviceProvider.GetRequiredService<IShardClient>();
        Stake = serviceProvider.GetRequiredService<IStakeClient>();
        Tokens = serviceProvider.GetRequiredService<ITokenClient>();
        Transactions = serviceProvider.GetRequiredService<ITransactionClient>();
        Usernames = serviceProvider.GetRequiredService<IUsernameClient>();
        WaitingList = serviceProvider.GetRequiredService<IWaitingListClient>();
        HealthCheck = serviceProvider.GetRequiredService<IHealthCheckClient>();
        DappConfig = serviceProvider.GetRequiredService<IDappConfigClient>();
        Websocket = serviceProvider.GetRequiredService<IWebsocketClient>();
        Transfers = serviceProvider.GetRequiredService<ITransferClient>();
        TransactionBatches = serviceProvider.GetRequiredService<ITransactionBatchClient>();
        Applications = serviceProvider.GetRequiredService<IApplicationClient>();
        Events = serviceProvider.GetRequiredService<IEventClient>();
        Marketplace = serviceProvider.GetRequiredService<IMarketplaceClient>();
        Pool = serviceProvider.GetRequiredService<IPoolClient>();
    }

    public NetworkType NetworkType { get; }

    public IXExchangeClient XExchange { get; }

    public INetworkClient Network { get; }

    public IAccountClient Accounts { get; }

    public IBlockClient Blocks { get; }

    public ICollectionClient Collections { get; }

    public IDelegationClient Delegation { get; }

    public IIdentityClient Identities { get; }

    public IKeyClient Keys { get; }

    public IMiniblockClient Miniblocks { get; }

    public INftClient Nfts { get; }

    public ITagClient Tags { get; }

    public INodeClient Nodes { get; }

    public IProviderClient Providers { get; }

    public IRoundClient Rounds { get; }

    public IResultClient Results { get; }

    public IShardClient Shards { get; }

    public IStakeClient Stake { get; }

    public ITokenClient Tokens { get; }

    public ITransactionClient Transactions { get; }

    public IUsernameClient Usernames { get; }

    public IWaitingListClient WaitingList { get; }

    public IHealthCheckClient HealthCheck { get; }

    public IDappConfigClient DappConfig { get; }

    public IWebsocketClient Websocket { get; }

    public ITransferClient Transfers { get; }

    public ITransactionBatchClient TransactionBatches { get; }

    public IApplicationClient Applications { get; }

    public IEventClient Events { get; }

    public IMarketplaceClient Marketplace { get; }

    public IPoolClient Pool { get; }
}
