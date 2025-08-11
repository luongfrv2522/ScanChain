namespace B39.ScanChain.Domain.Entities.Wallet;

public record WalletToken(
    string TokenAddress,
    string Symbol,
    string Name,
    string? Logo,
    string? Thumbnail,
    int Decimals,
    string Balance,
    bool PossibleSpam,
    bool VerifiedContract,
    string? TotalSupply,
    string? TotalSupplyFormatted,
    double? PercentageRelativeToTotalSupply,
    int? SecurityScore,
    string BalanceFormatted,
    double UsdPrice,
    double UsdPrice24hrPercentChange,
    double UsdPrice24hrUsdChange,
    double UsdValue,
    double UsdValue24hrUsdChange,
    bool NativeToken,
    double PortfolioPercentage
);