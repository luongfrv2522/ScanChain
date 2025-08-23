using AutoMapper;
using B39.ScanChain.Domain.Entities;
using B39.ScanChain.Domain.Entities.Wallet;
using B39.ScanChain.Infrastructure.Models.Wallet;

namespace B39.ScanChain.Infrastructure.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<WalletResponseModel, WalletInfo>();
        CreateMap<WalletTokenModel, WalletToken>();
        CreateMap<WalletTransactionsModel, WalletTransactions>();
        CreateMap<WalletTransactionItemModel, WalletTransactionItem>();
    }
}