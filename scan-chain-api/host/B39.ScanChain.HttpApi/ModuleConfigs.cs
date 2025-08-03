using B39.ScanChain.Application;
using B39.ScanChain.Infrastructure;

namespace B39.ScanChain.HttpApi;

public static class ModuleConfigs
{
    public static IServiceCollection AddModuleConfigs(this IServiceCollection services)
    {
        return services
            .AddApplicationConfig()
            .AddInfrastructureConfig();
    }
}