using B39.ScanChain.Infrastructure.Models.Wallet;
using Refit;

namespace B39.ScanChain.Infrastructure.WalletApi;

public interface IMoralisWalletApi
{
    [Get("/wallets/{address}/tokens")]
    Task<WalletResponseModel> GetNativeAndErc20AndTokenBalance(string address);
}