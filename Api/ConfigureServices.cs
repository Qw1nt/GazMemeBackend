using GazMeme.Common.Binders;

namespace GazMeme;

public static class ConfigureServices
{
    public static IServiceCollection AddEndpointBinders(this IServiceCollection services)
    {
        services.AddScoped<CreateDirectionBinder, CreateDirectionBinder>();
        services.AddScoped<CreateEventBinder, CreateEventBinder>();
        
        return services;
    }
}