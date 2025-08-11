using System.Text.Json.Serialization;

namespace B39.ScanChain.Infrastructure.Models.Wallet;

public record WalletResponseModel(
    [property: JsonPropertyName("cursor")] string? Cursor,
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("page_size")] int PageSize,
    [property: JsonPropertyName("block_number")] long BlockNumber,
    [property: JsonPropertyName("result")] List<WalletTokenModel> Result
);