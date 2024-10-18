using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Sidio.RevenueCat.Api.V1;
using Sidio.RevenueCat.Api.V2;

namespace Sidio.RevenueCat.Api;

public static class RevenueCatServiceCollectionExtensions
{
    public static IServiceCollection AddRevenueCatV1(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<RevenueCatV1Options>(namedConfigurationSection);

        services.AddSingleton<IRevenueCatV1Client>(
            x =>
                {
                    var revenueCatOptions = x.GetRequiredService<IOptions<RevenueCatV1Options>>();

                    var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                        revenueCatOptions.Value.ApiKey, "Bearer"
                    );

                    var options = new RestClientOptions(revenueCatOptions.Value.BaseUrl) { Authenticator = authenticator };

                    var restClient = new RestClient(options);
                    return new RevenueCatV1Client(restClient);
                });

        return services;
    }

    public static IServiceCollection AddRevenueCatV1(
        this IServiceCollection services,
        [ConstantExpected] string configurationSection = RevenueCatV1Options.SectionName)
    {
        services.AddOptions<RevenueCatV1Options>().Configure<IConfiguration>(
            (settings, configuration) => { configuration.GetSection(configurationSection).Bind(settings); });

        services.AddSingleton<IRevenueCatV1Client>(
            x =>
                {
                    var revenueCatOptions = x.GetRequiredService<IOptions<RevenueCatV1Options>>();

                    var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(
                        revenueCatOptions.Value.ApiKey, "Bearer"
                    );

                    var options = new RestClientOptions(revenueCatOptions.Value.BaseUrl) { Authenticator = authenticator };

                    var restClient = new RestClient(options);
                    return new RevenueCatV1Client(restClient);
                });

        return services;
    }

    public static IServiceCollection AddRevenueCatV2(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.Configure<RevenueCatV2Options>(namedConfigurationSection);

        services.AddSingleton<IRevenueCatV2Client>(
            x =>
                {
                    var revenueCatOptions = x.GetRequiredService<IOptions<RevenueCatV2Options>>();

                    var options = new RestClientOptions(revenueCatOptions.Value.BaseUrl);

                    var restClient = new RestClient(options);
                    return new RevenueCatV2Client(restClient);
                });

        return services;
    }

    public static IServiceCollection AddRevenueCatV2(
        this IServiceCollection services,
        [ConstantExpected] string configurationSection = RevenueCatV2Options.SectionName)
    {
        services.AddOptions<RevenueCatV2Options>().Configure<IConfiguration>(
            (settings, configuration) => { configuration.GetSection(configurationSection).Bind(settings); });

        services.AddSingleton<IRevenueCatV2Client>(
            x =>
                {
                    var revenueCatOptions = x.GetRequiredService<IOptions<RevenueCatV2Options>>();

                    var options = new RestClientOptions(revenueCatOptions.Value.BaseUrl);

                    var restClient = new RestClient(options);
                    return new RevenueCatV2Client(restClient);
                });

        return services;
    }
}