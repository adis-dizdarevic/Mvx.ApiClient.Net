#nullable enable
using System.Text.Json;
using Mvx.ApiClient.Net.Infrastructure;
using Mvx.ApiClient.Net.Models.Api;
using Mvx.ApiClient.Net.Requests.Tags;

namespace Mvx.ApiClient.Net.Clients;

internal sealed class TagClient : ITagClient
{
    private readonly ApiRequestExecutor _requestExecutor;

    public TagClient(HttpClient httpClient)
    {
        _requestExecutor = new ApiRequestExecutor(httpClient);
    }

    [ApiOperation("/tags", "TagController_getTags")]
    public async Task<IReadOnlyList<Tag>> GetTagsAsync(GetTagsOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "tags";
        var query = new QueryParameters();
        query.AddPagination(options?.Pagination);
        query.AddString("search", options?.Search);
        return await _requestExecutor.GetJsonAsync<IReadOnlyList<Tag>>(path, query, cancellationToken);
    }

    [ApiOperation("/tags/count", "TagController_getTagCount")]
    public async Task<long> GetTagCountAsync(GetTagCountOptions? options = null, CancellationToken cancellationToken = default)
    {
        var path = "tags/count";
        var query = new QueryParameters();
        query.AddString("search", options?.Search);
        return await _requestExecutor.GetInt64Async(path, query, cancellationToken);
    }

    [ApiOperation("/tags/{tag}", "TagController_getTagDetails")]
    public async Task<Tag> GetTagDetailsAsync(string tag, CancellationToken cancellationToken = default)
    {
        var path = $"tags/{ApiPath.EscapeRequired(tag.ToString(), nameof(tag))}";
        QueryParameters? query = null;
        return await _requestExecutor.GetJsonAsync<Tag>(path, query, cancellationToken);
    }

}
