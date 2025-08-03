using Microsoft.AspNetCore.Routing;

namespace B39.ScanChain.Application.Interfaces;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder builder);
}