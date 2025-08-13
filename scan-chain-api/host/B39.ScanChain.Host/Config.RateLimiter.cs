using System.Threading.RateLimiting;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.RateLimiting;

namespace B39.ScanChain.Host;

public static class RateLimiter
{
    public static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration config)
    {
        return services.AddOptions()
        .AddMemoryCache()
        .Configure<IpRateLimitOptions>(config.GetSection("IpRateLimiting"))
        .AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>()
        .AddInMemoryRateLimiting();
    }
}