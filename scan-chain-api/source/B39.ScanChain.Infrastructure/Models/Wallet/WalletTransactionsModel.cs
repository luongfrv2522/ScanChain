using System.Text.Json.Serialization;

namespace B39.ScanChain.Infrastructure.Models.Wallet;

public class WalletTransactionsModel
{
    [property: JsonPropertyName("cursor")]
    public string? Cursor { get; set; }
    
    [property: JsonPropertyName("page_size")]
    public int PageSize { get; set; }
    
    [property: JsonPropertyName("page")]
    public int Page { get; set; }
    
    [property: JsonPropertyName("result")]
    public List<WalletTransactionItemModel>? Result { get; set; }
}