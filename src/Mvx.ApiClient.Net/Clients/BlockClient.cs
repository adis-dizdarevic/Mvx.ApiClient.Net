using Mvx.ApiClient.Net.Dtos;
using Mvx.ApiClient.Net.Enums;
using Mvx.ApiClient.Net.Interfaces.Clients;
using Mvx.ApiClient.Net.Models.Block;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class BlockClient : IBlockClient
{
    public async Task<IEnumerable<BlockDto>> GetBlocksAsync(QueryParametersDto queryParameters, int? shard = null, string? proposer = null,
        string? validator = null, int? epoch = null, int? nonce = null, IEnumerable<string>? hashes = null,
        SortDirection? order = null, bool withProposerIdentity = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<BlockDetailedDto> GetLatestBlockAsync(int? ttl = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<BlockDetailedDto> GetBlockAsync(string hash, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetBlocksCountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
