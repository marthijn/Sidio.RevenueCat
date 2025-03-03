using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sidio.RevenueCat.Api.V1;
using Sidio.RevenueCat.Api.V2;

namespace Sidio.RevenueCat.Api;

public static class RevenueCatServiceCollectionExtensions
{
    public static IServiceCollection AddRevenueCatV1(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<RevenueCatV1Options>(namedConfigurationSection);
        services.AddSingleton<IRevenueCatV1Client, RevenueCatV1Client>();
        return services;
    }

    public static IServiceCollection AddRevenueCatV1(
        this IServiceCollection services,
        [ConstantExpected] string configurationSection = RevenueCatV1Options.SectionName)
    {
        services.AddOptions<RevenueCatV1Options>().Configure<IConfiguration>(
            (settings, configuration) => { configuration.GetSection(configurationSection).Bind(settings); });
        services.AddSingleton<IRevenueCatV1Client, RevenueCatV1Client>();
        return services;
    }

    public static IServiceCollection AddRevenueCatV2(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<RevenueCatV2Options>(namedConfigurationSection);
        services.AddSingleton<IRevenueCatV2Client, RevenueCatV2Client>();
        return services;
    }

    public static IServiceCollection AddRevenueCatV2(
        this IServiceCollection services,
        [ConstantExpected] string configurationSection = RevenueCatV2Options.SectionName)
    {
        services.AddOptions<RevenueCatV2Options>().Configure<IConfiguration>(
            (settings, configuration) => { configuration.GetSection(configurationSection).Bind(settings); });
        services.AddSingleton<IRevenueCatV2Client, RevenueCatV2Client>();
        return services;
    }
}