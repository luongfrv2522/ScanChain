using System.Reflection;
using B39.ScanChain.Application.Interfaces;
using Microsoft.AspNetCore.Routing;
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

    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpointTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false });

        foreach (var type in endpointTypes)
            if (ActivatorUtilities.CreateInstance(app.ServiceProvider, type) is IEndpoint endpoint)
                endpoint.MapEndpoint(app);
    }
}