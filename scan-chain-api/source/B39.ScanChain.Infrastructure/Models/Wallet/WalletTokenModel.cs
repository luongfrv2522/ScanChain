using System.Text.Json.Serialization;

namespace B39.ScanChain.Infrastructure.Models.Wallet;

public record WalletTokenModel(
    [property: JsonPropertyName("token_address")] string TokenAddress,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("logo")] string? Logo,
    [property: JsonPropertyName("thumbnail")] string? Thumbnail,
    [property: JsonPropertyName("decimals")] int Decimals,
    [property: JsonPropertyName("balance")] string Balance,
    [property: JsonPropertyName("possible_spam")] bool PossibleSpam,
    [property: JsonPropertyName("verified_contract")] bool VerifiedContract,
    [property: JsonPropertyName("total_supply")] string? TotalSupply,
    [property: JsonPropertyName("total_supply_formatted")] string? TotalSupplyFormatted,
    [property: JsonPropertyName("percentage_relative_to_total_supply")] double? PercentageRelativeToTotalSupply,
    [property: JsonPropertyName("security_score")] int? SecurityScore,
    [property: JsonPropertyName("balance_formatted")] string BalanceFormatted,
    [property: JsonPropertyName("usd_price")] double UsdPrice,
    [property: JsonPropertyName("usd_price_24hr_percent_change")] double UsdPrice24hrPercentChange,
    [property: JsonPropertyName("usd_price_24hr_usd_change")] double UsdPrice24hrUsdChange,
    [property: JsonPropertyName("usd_value")] double UsdValue,
    [property: JsonPropertyName("usd_value_24hr_usd_change")] double UsdValue24hrUsdChange,
    [property: JsonPropertyName("native_token")] bool NativeToken,
    [property: JsonPropertyName("portfolio_percentage")] double PortfolioPercentage
);