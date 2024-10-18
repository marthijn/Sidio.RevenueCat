namespace Sidio.RevenueCat.Api.V2;

public sealed class RevenueCatV2Options
{
    public const string SectionName = "RevenueCatV2";

    public required string BaseUrl { get; set; }

    public required string ApiKey { get; set; }
}