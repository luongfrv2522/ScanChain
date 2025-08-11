using System.Net.Http.Headers;
using System.Reflection;
using B39.ScanChain.Domain.Interfaces.Repositories;
using B39.ScanChain.Infrastructure.Repositories;
using B39.ScanChain.Infrastructure.WalletApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace B39.ScanChain.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration config)
    {
        return services.AddApiServices(config)
            .AddScoped<IWalletRepository, MoralisWalletRepository>();
    }
    
    private static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
    {
        var moralisApiKey = config["Moralis:ApiKey"];
        services
            .AddRefitClient<IMoralisWalletApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://deep-index.moralis.io/api/v2.2");
                var headers = c.DefaultRequestHeaders;
                headers.Add("X-API-Key", moralisApiKey);
                headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

        return services;
    }
}