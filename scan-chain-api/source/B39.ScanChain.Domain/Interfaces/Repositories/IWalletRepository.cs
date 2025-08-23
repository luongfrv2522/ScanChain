using B39.ScanChain.Domain.Entities;
using B39.ScanChain.Domain.Entities.Wallet;

namespace B39.ScanChain.Domain.Interfaces.Repositories;

public interface IWalletRepository
{
    public Task<WalletInfo> GetNativeAndErc20AndTokenBalance(string address);
    public Task<WalletTransactions> GetTransactions(string address);
}