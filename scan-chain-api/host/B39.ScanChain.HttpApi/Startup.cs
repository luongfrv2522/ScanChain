using System.Net.Http.Headers;
using System.Text;
using B39.ScanChain.Infrastructure.WalletApi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;

namespace B39.ScanChain.HttpApi;

public static class Startup
{
    public static AuthenticationBuilder AddAuthenticationJwt(this IServiceCollection services, IConfigurationSection jwtSettings)
    {
        var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey not configured");
        var key = Encoding.UTF8.GetBytes(secretKey);
        
        return services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        })
        .AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = jwtSettings["Audience"],
                ValidIssuer = jwtSettings["Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true
            };
        });
    }
    public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScanChain API", Version = "v1" });

            // 🔐 Bearer Token
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Enter: Bearer {your token}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
    
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
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