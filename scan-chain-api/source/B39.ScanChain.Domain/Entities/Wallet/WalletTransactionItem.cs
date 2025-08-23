namespace B39.ScanChain.Domain.Entities.Wallet;

public class WalletTransactionItem
{
    public string Hash { get; set; }
    public long Nonce { get; set; }
    public int TransactionIndex { get; set; }
    public string FromAddressEntity { get; set; }
    public string FromAddressEntityLogo { get; set; }
    public string FromAddress { get; set; }
    public string FromAddressLabel { get; set; }
    public string ToAddressEntity { get; set; }
    public string ToAddressEntityLogo { get; set; }
    public string ToAddress { get; set; }
    public string ToAddressLabel { get; set; }
    public string Value { get; set; }
    public long Gas { get; set; }
    public long GasPrice { get; set; }
    public string Input { get; set; }
    public long ReceiptCumulativeGasUsed { get; set; }
    public long ReceiptGasUsed { get; set; }
    public string ReceiptContractAddress { get; set; }
    public string ReceiptRoot { get; set; }
    public int ReceiptStatus { get; set; }
    public DateTime BlockTimestamp { get; set; }
    public long BlockNumber { get; set; }
    public string BlockHash { get; set; }
    public List<long> TransferIndex { get; set; }
    public decimal TransactionFee { get; set; }
}
