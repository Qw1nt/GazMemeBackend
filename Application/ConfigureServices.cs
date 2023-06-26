using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Common.Services;
using FastEndpoints.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var authenticationConfig = configuration.GetSection(Constants.AuthenticationConfigSection)
            .Get<AuthenticationConfiguration>();
        services.AddSingleton<AuthenticationConfiguration>(authenticationConfig);
        
        services.AddJWTBearerAuth(authenticationConfig.BearerKey);
        services.AddScoped<IHashSaltService, HashSaltService>();
        services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

        services.AddScoped<IPostRepository, PostRepository>();
        
        return services;
    }
}