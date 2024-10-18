namespace Sidio.RevenueCat.Api.V1;

public sealed class RevenueCatV1Options
{
    public const string SectionName = "RevenueCatV1";

    public required string BaseUrl { get; set; }

    public required string ApiKey { get; set; }
}