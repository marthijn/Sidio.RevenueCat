using Microsoft.Extensions.DependencyInjection;

namespace Sidio.RevenueCat.Webhooks;

public static class RevenueCatWebhooksServiceCollectionExtensions
{
    public static IServiceCollection AddRevenueCatWebhookServices(this IServiceCollection services)
    {
        services.AddSingleton<IRevenueCatWebhookService, RevenueCatWebhookService>();

        return services;
    }
}