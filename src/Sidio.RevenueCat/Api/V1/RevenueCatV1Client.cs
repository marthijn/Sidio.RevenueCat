using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Api.V1;

public sealed class RevenueCatV1Client : IRevenueCatV1Client, IDisposable
{
    private readonly IRestClient _client;

    public RevenueCatV1Client(IOptions<RevenueCatV1Options> options)
    {
        var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
            options.Value.ApiKey, "Bearer"
        );
        var restClientOptions = new RestClientOptions(options.Value.BaseUrl) { Authenticator = authenticator };
        _client = new RestClient(restClientOptions);
    }

    private RevenueCatV1Client(IRestClient restClient)
    {
        _client = restClient;
    }

    public async Task<HttpResult<SubscriberResponse>> GetOrCreateSubscriberAsync(string appUserId, CancellationToken cancellationToken = default)
    {
        var request = new RestRequest($"subscribers/{appUserId}");
        var response = await _client.ExecuteGetAsync<SubscriberResponse>(request, cancellationToken).ConfigureAwait(false);
        return new HttpResult<SubscriberResponse>(response);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    internal static RevenueCatV1Client Create(IRestClient restClient)
    {
        return new RevenueCatV1Client(restClient);
    }
}