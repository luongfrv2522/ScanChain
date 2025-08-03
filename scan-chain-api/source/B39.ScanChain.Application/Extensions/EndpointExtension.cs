using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
}