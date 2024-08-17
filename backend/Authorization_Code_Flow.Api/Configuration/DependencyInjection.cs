using Authorization_Code_Flow.Api.Interfaces;
using Authorization_Code_Flow.Api.Services;
using Authorization_Code_Flow.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Authorization_Code_Flow.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdpService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdpService, IdpService>();

            services
                .Configure<KeyCloakOptions>(configuration.GetSection("IdentityProvider:KeyCloak"))
                .AddTransient<IIdentityProviderService, IdentityProviderService>();

            services.AddTransient<KeyCloakAuthDelegatingHandler>();
            services.AddHttpClient<IKeyCloakClient, KeyCloakClient>((serviceProvider, httpClient) =>
            {
                var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

                var realmUrl = keycloakOptions.RealmUrl;

                httpClient.BaseAddress = new Uri(realmUrl);
            }).AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

            return services;
        }
    }
}
