using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace B39.ScanChain.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services)
    {
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}