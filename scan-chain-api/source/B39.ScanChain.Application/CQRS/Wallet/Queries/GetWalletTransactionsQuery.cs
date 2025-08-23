using B39.Common.Extensions;
using B39.ScanChain.Application.Exceptions;
using B39.ScanChain.Application.Extensions;
using B39.ScanChain.Application.Interfaces;
using B39.ScanChain.Domain.Entities.Wallet;
using B39.ScanChain.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace B39.ScanChain.Application.CQRS.Wallet.Queries;

public class GetWalletTransactionsQuery: IRequest<WalletTransactions>, IEndpoint
{
    public string? Address { set; get; }
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet<GetWalletTransactionsQuery, WalletTransactions>("/wallet/transactions")
            .WithTags("Wallet")
            .WithOpenApi()
            .AllowAnonymous();
    }
}

public class GetWalletTransactionsHandler(IWalletRepository walletRepository) : IRequestHandler<GetWalletTransactionsQuery, WalletTransactions>
{
    public async Task<WalletTransactions> Handle(GetWalletTransactionsQuery request, CancellationToken cancellationToken)
    {
        if (request.Address.IsNullOrEmpty()) throw new AppException("444");

        var balance = await walletRepository.GetTransactions(request.Address);
        balance.Address = request.Address;
        return balance;
    }
}