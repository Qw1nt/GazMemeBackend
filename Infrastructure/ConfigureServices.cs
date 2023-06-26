using Application.Common.Interfaces;
using Application.Common.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Services.FileSaveService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(Constants.DatabaseSection));
        });

        services.AddScoped<IApplicationDataContext, ApplicationDataContext>();
        services.AddScoped<IFileSaveService, FileSaveServiceDefault>();

        return services;
    }
}