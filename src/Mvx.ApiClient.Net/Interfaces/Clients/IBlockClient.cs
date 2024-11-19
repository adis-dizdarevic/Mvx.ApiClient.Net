using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Models.Block;

namespace Mvx.ApiClient.Net.Interfaces.Clients;

/// <summary>
/// Client for retrieving information about blocks
/// </summary>
public interface IBlockClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryParameters"></param>
    /// <param name="shard"></param>
    /// <param name="proposer"></param>
    /// <param name="validator"></param>
    /// <param name="epoch"></param>
    /// <param name="nonce"></param>
    /// <param name="hashes"></param>
    /// <param name="order"></param>
    /// <param name="withProposerIdentity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<BlockDto>> GetBlocksAsync(QueryParametersDto queryParameters, int? shard = null, string? proposer = null, string? validator = null, int? epoch = null,
        int? nonce = null, IEnumerable<string>? hashes = null, SortDirection? order = null, bool withProposerIdentity = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ttl"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BlockDetailedDto> GetLatestBlockAsync(int? ttl = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns block information details for a given hash
    /// </summary>
    /// <param name="hash">The hash of the block</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A <see cref="BlockDetailedDto"/> object containing detailed information about the block</returns>
    Task<BlockDetailedDto> GetBlockAsync(string hash, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> GetBlocksCountAsync(CancellationToken cancellationToken = default);
}
