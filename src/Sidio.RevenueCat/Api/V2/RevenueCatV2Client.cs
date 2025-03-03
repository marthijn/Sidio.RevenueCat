using Microsoft.Extensions.Options;
using RestSharp;
using Sidio.RevenueCat.Api.V2.Responses;

namespace Sidio.RevenueCat.Api.V2;

public sealed class RevenueCatV2Client : IRevenueCatV2Client, IDisposable
{
    private readonly IRestClient _client;

    public RevenueCatV2Client(IOptions<RevenueCatV2Options> options)
    {
        var restClientOptions = new RestClientOptions(options.Value.BaseUrl);
        _client = new RestClient(restClientOptions);
    }

    private RevenueCatV2Client(IRestClient restClient)
    {
        _client = restClient;
    }

    public async Task<HttpResult<PagedResponse<ProjectResponse>>> GetProjectsAsync(
        int limit = Constants.DefaultLimit,
        string? startingAfterId = null,
        CancellationToken cancellationToken = default)
    {
        var request = new RestRequest("projects");
        request.AddQueryParameter("limit", limit.ToString());
        if (!string.IsNullOrWhiteSpace(startingAfterId))
        {
            request.AddQueryParameter("starting_after", startingAfterId);
        }

        var response = await _client.ExecuteGetAsync<PagedResponse<ProjectResponse>>(request, cancellationToken).ConfigureAwait(false);
        return new HttpResult<PagedResponse<ProjectResponse>>(response);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    internal static RevenueCatV2Client Create(IRestClient restClient)
    {
        return new RevenueCatV2Client(restClient);
    }
}