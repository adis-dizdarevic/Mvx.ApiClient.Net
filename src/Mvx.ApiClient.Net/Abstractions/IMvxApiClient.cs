namespace Mvx.ApiClient.Net;

/// <summary>Root client that exposes the MultiversX API endpoint groups.</summary>
public interface IMvxApiClient
{
    /// <summary>Gets the configured MultiversX network.</summary>
    NetworkType NetworkType { get; }

    /// <summary>Gets the xExchange endpoint client.</summary>
    IXExchangeClient XExchange { get; }

    /// <summary>Gets the network information endpoint client.</summary>
    INetworkClient Network { get; }

    /// <summary>Gets the account endpoint client.</summary>
    IAccountClient Accounts { get; }

    /// <summary>Gets the block endpoint client.</summary>
    IBlockClient Blocks { get; }

    /// <summary>Gets the collection endpoint client.</summary>
    ICollectionClient Collections { get; }

    /// <summary>Gets the delegation endpoint client.</summary>
    IDelegationClient Delegation { get; }

    /// <summary>Gets the identity endpoint client.</summary>
    IIdentityClient Identities { get; }

    /// <summary>Gets the validator-key endpoint client.</summary>
    IKeyClient Keys { get; }

    /// <summary>Gets the miniblock endpoint client.</summary>
    IMiniblockClient Miniblocks { get; }

    /// <summary>Gets the NFT endpoint client.</summary>
    INftClient Nfts { get; }

    /// <summary>Gets the tag endpoint client.</summary>
    ITagClient Tags { get; }

    /// <summary>Gets the node endpoint client.</summary>
    INodeClient Nodes { get; }

    /// <summary>Gets the staking-provider endpoint client.</summary>
    IProviderClient Providers { get; }

    /// <summary>Gets the round endpoint client.</summary>
    IRoundClient Rounds { get; }

    /// <summary>Gets the smart-contract-result endpoint client.</summary>
    IResultClient Results { get; }

    /// <summary>Gets the shard endpoint client.</summary>
    IShardClient Shards { get; }

    /// <summary>Gets the global staking endpoint client.</summary>
    IStakeClient Stake { get; }

    /// <summary>Gets the fungible-token endpoint client.</summary>
    ITokenClient Tokens { get; }

    /// <summary>Gets the transaction endpoint client.</summary>
    ITransactionClient Transactions { get; }

    /// <summary>Gets the username endpoint client.</summary>
    IUsernameClient Usernames { get; }

    /// <summary>Gets the waiting-list endpoint client.</summary>
    IWaitingListClient WaitingList { get; }

    /// <summary>Gets the API health endpoint client.</summary>
    IHealthCheckClient HealthCheck { get; }

    /// <summary>Gets the dApp configuration endpoint client.</summary>
    IDappConfigClient DappConfig { get; }

    /// <summary>Gets the websocket configuration endpoint client.</summary>
    IWebsocketClient Websocket { get; }

    /// <summary>Gets the transfer endpoint client.</summary>
    ITransferClient Transfers { get; }

    /// <summary>Gets the transaction-batch endpoint client.</summary>
    ITransactionBatchClient TransactionBatches { get; }

    /// <summary>Gets the application endpoint client.</summary>
    IApplicationClient Applications { get; }

    /// <summary>Gets the event endpoint client.</summary>
    IEventClient Events { get; }

    /// <summary>Gets the marketplace endpoint client.</summary>
    IMarketplaceClient Marketplace { get; }

    /// <summary>Gets the transaction-pool endpoint client.</summary>
    IPoolClient Pool { get; }
}
