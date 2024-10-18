using Sidio.RevenueCat.Api.V2.Responses;

namespace Sidio.RevenueCat.Api.V2;

public interface IRevenueCatV2Client
{
    Task<HttpResult<PagedResponse<ProjectResponse>>> GetProjectsAsync(
        int limit = Constants.DefaultLimit,
        string? startingAfterId = null,
        CancellationToken cancellationToken = default);
}