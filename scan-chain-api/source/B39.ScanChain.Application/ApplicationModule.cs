using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace B39.ScanChain.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}