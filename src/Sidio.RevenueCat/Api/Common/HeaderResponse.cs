using RestSharp;

namespace Sidio.RevenueCat.Api.Common;

public sealed class HeaderResponse
{
    public HeaderResponse(Parameter? rateLimitCurrentUsage, Parameter? rateLimitCurrentLimit)
    {
        if (int.TryParse(rateLimitCurrentUsage?.Value?.ToString() ?? string.Empty, out var rateLimitCurrentUsageValue))
        {
            RateLimitCurrentUsage = rateLimitCurrentUsageValue;
        }

        if (int.TryParse(rateLimitCurrentLimit?.Value?.ToString() ?? string.Empty, out var rateLimitCurrentLimitValue))
        {
            RateLimitCurrentLimit = rateLimitCurrentLimitValue;
        }
    }

    public HeaderResponse(int rateLimitCurrentUsage, int rateLimitCurrentLimit)
    {
        RateLimitCurrentUsage = rateLimitCurrentUsage;
        RateLimitCurrentLimit = rateLimitCurrentLimit;
    }

    public int? RateLimitCurrentUsage { get; }

    public int? RateLimitCurrentLimit { get; }
}