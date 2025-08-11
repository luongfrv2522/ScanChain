using AutoMapper;
using B39.Common.Extensions;
using B39.ScanChain.Application.Exceptions;
using B39.ScanChain.Application.Extensions;
using B39.ScanChain.Application.Interfaces;
using B39.ScanChain.Domain.Entities;
using B39.ScanChain.Domain.Entities.Wallet;
using B39.ScanChain.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace B39.ScanChain.Application.CQRS.Queries;

public class GetWalletInfoQuery: IRequest<WalletInfo>
{
    public string? Address { set; get; }
}

public class GetWalletInfoEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet<GetWalletInfoQuery, WalletInfo>("/wallet/info")
            .WithName(nameof(GetWalletInfoEndpoint))
            .WithTags("Wallet")
            .WithOpenApi()
            .AllowAnonymous();
    }
}

public class GetOneUserHandler(IWalletRepository walletRepository) : IRequestHandler<GetWalletInfoQuery, WalletInfo>
{
    public async Task<WalletInfo> Handle(GetWalletInfoQuery request, CancellationToken cancellationToken)
    {
        if (request.Address.IsNullOrEmpty()) throw new AppException("444");

        var balance = await walletRepository.GetNativeAndErc20AndTokenBalance(request.Address);
        return balance;
    }
}