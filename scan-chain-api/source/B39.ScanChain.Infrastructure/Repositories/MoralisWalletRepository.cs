using AutoMapper;
using B39.ScanChain.Domain.Entities;
using B39.ScanChain.Domain.Entities.Wallet;
using B39.ScanChain.Domain.Interfaces.Repositories;
using B39.ScanChain.Infrastructure.WalletApi;

namespace B39.ScanChain.Infrastructure.Repositories;

public class MoralisWalletRepository(IMoralisWalletApi moralisWalletApi, IMapper mapper) : IWalletRepository
{
    public async Task<WalletInfo> GetNativeAndErc20AndTokenBalance(string address)
    {
        var result = await moralisWalletApi.GetNativeAndErc20AndTokenBalance(address);
        return mapper.Map<WalletInfo>(result);
    }
}