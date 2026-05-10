namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade transaction log item.
/// </summary>
public record BybitPreUpgradeTransaction
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory? Category { get; set; }

    /// <summary>
    /// Side.
    /// </summary>
    public BybitPositionSide? Side { get; set; }

    /// <summary>
    /// Transaction timestamp in milliseconds.
    /// </summary>
    [JsonProperty("transactionTime")]
    public long TransactionTimestamp { get; set; }

    /// <summary>
    /// Transaction time.
    /// </summary>
    public DateTime TransactionTime { get => TransactionTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Transaction type.
    /// </summary>
    public BybitTransactionType? Type { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Size.
    /// </summary>
    public decimal? Size { get; set; }

    /// <summary>
    /// Currency.
    /// </summary>
    [JsonProperty("currency")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Trade price.
    /// </summary>
    public decimal? TradePrice { get; set; }

    /// <summary>
    /// Funding fee.
    /// </summary>
    [JsonProperty("funding")]
    public decimal? FundingFee { get; set; }

    /// <summary>
    /// Trading fee.
    /// </summary>
    public decimal? Fee { get; set; }

    /// <summary>
    /// Cash flow.
    /// </summary>
    public decimal? CashFlow { get; set; }

    /// <summary>
    /// Change.
    /// </summary>
    public decimal? Change { get; set; }

    /// <summary>
    /// Cash balance.
    /// </summary>
    public decimal? CashBalance { get; set; }

    /// <summary>
    /// Fee rate.
    /// </summary>
    public decimal? FeeRate { get; set; }

    /// <summary>
    /// Bonus change.
    /// </summary>
    public decimal? BonusChange { get; set; }

    /// <summary>
    /// Trade ID.
    /// </summary>
    public string TradeId { get; set; } = string.Empty;

    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;
}
