using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Mailgun.HttpClients.Registrars;
using Soenneker.Mailgun.OpenApiClientUtil.Abstract;

namespace Soenneker.Mailgun.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class MailgunOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="MailgunOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddMailgunOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddMailgunOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IMailgunOpenApiClientUtil, MailgunOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="MailgunOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddMailgunOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddMailgunOpenApiHttpClientAsSingleton()
                .TryAddScoped<IMailgunOpenApiClientUtil, MailgunOpenApiClientUtil>();

        return services;
    }
}
