namespace B39.ScanChain.Domain.Entities.Wallet;

public class WalletTransactions
{
    public string? Cursor { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public string? Address { get; set; }
    public List<WalletTransactionItem>? Result { get; set; }
}