namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert quote.
/// </summary>
public record BybitAssetConvertQuote
{
    /// <summary>
    /// Quote transaction ID.
    /// </summary>
    [JsonProperty("quoteTxId")]
    public string QuoteTransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Quoted exchange rate.
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Source coin.
    /// </summary>
    public string FromCoin { get; set; } = string.Empty;

    /// <summary>
    /// Source coin account type.
    /// </summary>
    public string FromCoinType { get; set; } = string.Empty;

    /// <summary>
    /// Destination coin.
    /// </summary>
    public string ToCoin { get; set; } = string.Empty;

    /// <summary>
    /// Destination coin account type.
    /// </summary>
    public string ToCoinType { get; set; } = string.Empty;

    /// <summary>
    /// Source coin amount.
    /// </summary>
    public decimal FromAmount { get; set; }

    /// <summary>
    /// Destination coin amount.
    /// </summary>
    public decimal ToAmount { get; set; }

    /// <summary>
    /// Quote expiry timestamp in milliseconds.
    /// </summary>
    public long ExpiredTime { get; set; }

    /// <summary>
    /// Custom request ID.
    /// </summary>
    public string RequestId { get; set; } = string.Empty;

    /// <summary>
    /// Extended tax and fee details.
    /// </summary>
    public JArray ExtTaxAndFee { get; set; } = [];
}
