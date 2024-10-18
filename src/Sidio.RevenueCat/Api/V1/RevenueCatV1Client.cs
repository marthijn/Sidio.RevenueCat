using RestSharp;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Api.V1;

public sealed class RevenueCatV1Client : IRevenueCatV1Client
{
    private readonly IRestClient _client;

    public RevenueCatV1Client(IRestClient client)
    {
        _client = client;
    }

    public async Task<HttpResult<SubscriberResponse>> GetOrCreateSubscriberAsync(string appUserId, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"subscribers/{appUserId}");
        var response = await _client.ExecuteGetAsync<SubscriberResponse>(request, cancellationToken).ConfigureAwait(false);
        return new HttpResult<SubscriberResponse>(response);
    }
}