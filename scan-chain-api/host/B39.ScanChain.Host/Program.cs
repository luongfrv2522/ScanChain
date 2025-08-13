using B39.ScanChain.Application.Extensions;
using B39.ScanChain.Host;
using B39.ScanChain.Host.Middlewares;
using B39.ScanChain.Infrastructure.Configurations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Config JWT
var configs = builder.Configuration;
var jwtSettings = configs.GetSection(nameof(JwtSettings));
builder.Services
    .Configure<JwtSettings>(jwtSettings)
    .AddAuthenticationJwt(jwtSettings);
builder.Services.AddAuthorization();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddModuleConfigs(configs);

builder.Host.UseSerilog((ctx, services, config) =>
{
    config
        .ReadFrom.Configuration(ctx.Configuration)
        .ReadFrom.Services(services);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapGroup("/api")
    .MapEndpoints();

app.Run();