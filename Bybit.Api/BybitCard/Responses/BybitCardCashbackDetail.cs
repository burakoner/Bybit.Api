namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card cashback detail.
/// </summary>
public record BybitCardCashbackDetail
{
    /// <summary>
    /// Point amount.
    /// </summary>
    public long Points { get; set; }

    /// <summary>
    /// Cashback amount.
    /// </summary>
    [JsonProperty("amt")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Currency.
    /// </summary>
    [JsonProperty("ccy")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Currency type.
    /// </summary>
    [JsonProperty("ccyType")]
    public BybitCardCashbackCurrencyType CurrencyType { get; set; }

    /// <summary>
    /// Creation time.
    /// </summary>
    public string CreateTime { get; set; } = string.Empty;

    /// <summary>
    /// Order ID.
    /// </summary>
    [JsonProperty("bizTxnId")]
    public string BusinessTransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Coupon or voucher ID.
    /// </summary>
    public long SourceId { get; set; }

    /// <summary>
    /// External order ID.
    /// </summary>
    public string SourceCode { get; set; } = string.Empty;

    /// <summary>
    /// Order status.
    /// </summary>
    public int OrderStatus { get; set; }

    /// <summary>
    /// Order sub-status.
    /// </summary>
    public int OrderSubStatus { get; set; }

    /// <summary>
    /// Display status.
    /// </summary>
    public BybitCardCashbackOrderShowStatus OrderShowStatus { get; set; }

    /// <summary>
    /// Failure reason code.
    /// </summary>
    public string FailedBizCode { get; set; } = string.Empty;
}
