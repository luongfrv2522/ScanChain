using System.Reflection;
using B39.ScanChain.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace B39.ScanChain.Application.Extensions;

public static class EndpointExtension
{
    public static IEndpointConventionBuilder MapPost<TRequest, TResponse>(this IEndpointRouteBuilder builder,
        string path) where TRequest : IRequest<TResponse>
    {
        return builder.MapPost(path,
            async ([FromBody] TRequest request, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));
    }

    public static IEndpointConventionBuilder MapGet<TRequest, TResponse>(this IEndpointRouteBuilder builder,
        string path) where TRequest : IRequest<TResponse>
    {
        return builder.MapGet(path,
            async ([AsParameters] TRequest request, IMediator mediator, CancellationToken cancellationToken) =>
            await mediator.Send(request, cancellationToken));
    }
    
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpointTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false });

        foreach (var type in endpointTypes)
            if (ActivatorUtilities.CreateInstance(app.ServiceProvider, type) is IEndpoint endpoint)
                endpoint.MapEndpoint(app);
    }
    
    public static IEndpointConventionBuilder WithEndPointName<T>(this IEndpointConventionBuilder builder)
    {
        var typeName = typeof(T).Name;
        if (typeName.EndsWith("Endpoint"))
            typeName = typeName[..^"Endpoint".Length];
        return builder.WithName(typeName);
    }
}