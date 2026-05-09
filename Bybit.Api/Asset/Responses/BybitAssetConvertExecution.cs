namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert execution response.
/// </summary>
public record BybitAssetConvertExecution
{
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; } = string.Empty;

    public BybitConvertStatus ExchangeStatus { get; set; }
}
