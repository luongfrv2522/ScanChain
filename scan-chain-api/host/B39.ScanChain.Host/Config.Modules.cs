using B39.ScanChain.Application;
using B39.ScanChain.Infrastructure;

namespace B39.ScanChain.Host;

public static class Modules
{
    public static IServiceCollection AddModuleConfigs(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddApplicationConfig()
            .AddInfrastructureConfig(config);
    }
}