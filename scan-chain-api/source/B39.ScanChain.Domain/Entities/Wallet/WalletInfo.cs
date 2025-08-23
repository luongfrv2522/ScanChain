namespace B39.ScanChain.Domain.Entities.Wallet;

public class WalletInfo
{
    public string? Cursor {get;set;}
    public int Page {get;set;}
    public int PageSize {get;set;}
    public long BlockNumber {get;set;}
    public string? Address  {get;set;}
    public List<WalletToken>? Result   {get;set;}
}