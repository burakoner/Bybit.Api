namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert quote.
/// </summary>
public record BybitAssetConvertQuote
{
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; } = string.Empty;

    public decimal ExchangeRate { get; set; }
    public string FromCoin { get; set; } = string.Empty;
    public string FromCoinType { get; set; } = string.Empty;
    public string ToCoin { get; set; } = string.Empty;
    public string ToCoinType { get; set; } = string.Empty;
    public decimal FromAmount { get; set; }
    public decimal ToAmount { get; set; }
    public long ExpiredTime { get; set; }
    public string RequestId { get; set; } = string.Empty;
    public JArray ExtTaxAndFee { get; set; } = [];
}
