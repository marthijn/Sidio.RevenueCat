using Essentia.Web.RevenueCat.Api.V1.Responses;
using Sidio.RevenueCat.Api.V1.Responses;

namespace Sidio.RevenueCat.Api.V1;

public interface IRevenueCatV1Client
{
    Task<HttpResult<SubscriberResponse>> GetOrCreateSubscriberAsync(string appUserId, CancellationToken cancellationToken = default);
}