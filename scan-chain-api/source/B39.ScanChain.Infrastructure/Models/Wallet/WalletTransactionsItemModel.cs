namespace B39.ScanChain.Infrastructure.Models.Wallet;

using System.Text.Json.Serialization;

public class WalletTransactionItemModel
{
    [property: JsonPropertyName("hash")]
    public string Hash { get; set; }

    [property: JsonPropertyName("nonce")]
    public string Nonce { get; set; }

    [property: JsonPropertyName("transaction_index")]
    public string TransactionIndex { get; set; }

    [property: JsonPropertyName("from_address_entity")]
    public string FromAddressEntity { get; set; }

    [property: JsonPropertyName("from_address_entity_logo")]
    public string FromAddressEntityLogo { get; set; }

    [property: JsonPropertyName("from_address")]
    public string FromAddress { get; set; }

    [property: JsonPropertyName("from_address_label")]
    public string FromAddressLabel { get; set; }

    [property: JsonPropertyName("to_address_entity")]
    public string ToAddressEntity { get; set; }

    [property: JsonPropertyName("to_address_entity_logo")]
    public string ToAddressEntityLogo { get; set; }

    [property: JsonPropertyName("to_address")]
    public string ToAddress { get; set; }

    [property: JsonPropertyName("to_address_label")]
    public string ToAddressLabel { get; set; }

    [property: JsonPropertyName("value")]
    public string Value { get; set; }   // có thể đổi sang decimal nếu bạn convert Wei

    [property: JsonPropertyName("gas")]
    public string Gas { get; set; }

    [property: JsonPropertyName("gas_price")]
    public string GasPrice { get; set; }

    [property: JsonPropertyName("input")]
    public string Input { get; set; }

    [property: JsonPropertyName("receipt_cumulative_gas_used")]
    public string ReceiptCumulativeGasUsed { get; set; }

    [property: JsonPropertyName("receipt_gas_used")]
    public string ReceiptGasUsed { get; set; }

    [property: JsonPropertyName("receipt_contract_address")]
    public string ReceiptContractAddress { get; set; }

    [property: JsonPropertyName("receipt_root")]
    public string ReceiptRoot { get; set; }

    [property: JsonPropertyName("receipt_status")]
    public string ReceiptStatus { get; set; }

    [property: JsonPropertyName("block_timestamp")]
    public DateTime BlockTimestamp { get; set; }

    [property: JsonPropertyName("block_number")]
    public string BlockNumber { get; set; }

    [property: JsonPropertyName("block_hash")]
    public string BlockHash { get; set; }

    [property: JsonPropertyName("transfer_index")]
    public List<long> TransferIndex { get; set; }

    [property: JsonPropertyName("transaction_fee")]
    public string TransactionFee { get; set; }
}
