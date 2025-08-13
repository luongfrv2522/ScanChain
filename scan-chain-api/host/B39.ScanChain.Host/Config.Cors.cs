namespace B39.ScanChain.Host;

public static class Cors
{
    public const string PolicyName = "CorsPolicy";

    public static IServiceCollection AddAppCors(this IServiceCollection services, IConfiguration config)
    {
        var allowedOrigins = config
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? Array.Empty<string>();

        return services.AddCors(options =>
        {
            options.AddPolicy(PolicyName, policy =>
            {
                policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}