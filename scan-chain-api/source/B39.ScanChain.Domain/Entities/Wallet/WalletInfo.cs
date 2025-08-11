namespace B39.ScanChain.Domain.Entities.Wallet;

public record WalletInfo(
    string? Cursor,
    int Page,
    int PageSize,
    long BlockNumber,
    List<WalletToken> Result    
);