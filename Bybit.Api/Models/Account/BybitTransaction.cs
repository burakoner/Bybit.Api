namespace Bybit.Api.Models.Account;

/// <summary>
/// Transaction info
/// </summary>
public class BybitTransaction
{
    /// <summary>
    /// Unique id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Product
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitPositionSide>))]
    public BybitPositionSide Side { get; set; }

    /// <summary>
    /// Transaction time
    /// </summary>
    [JsonProperty("transactionTime")]
    public long TransactionTimestamp { get; set; }

    /// <summary>
    /// Transaction time
    /// </summary>
    public DateTime TransactionTime { get => TransactionTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Type
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitTransactionType>))]
    public BybitTransactionType Type { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Size
    /// </summary>
    public decimal? Size { get; set; }

    /// <summary>
    /// Asset
    /// </summary>
    [JsonProperty("currency")]
    public string Asset { get; set; }

    /// <summary>
    /// Trade price
    /// </summary>
    public decimal? TradePrice { get; set; }

    /// <summary>
    /// Funding fee
    /// </summary>
    [JsonProperty("funding")]
    public decimal? FundingFee { get; set; }

    /// <summary>
    /// Trading fee
    /// </summary>
    public decimal? Fee { get; set; }

    /// <summary>
    /// Cash flow
    /// </summary>
    public decimal? CashFlow { get; set; }

    /// <summary>
    /// Change
    /// </summary>
    public decimal? Change { get; set; }

    /// <summary>
    /// Cash balance
    /// </summary>
    public decimal? CashBalance { get; set; }

    /// <summary>
    /// Fee rate
    /// </summary>
    public decimal? FeeRate { get; set; }

    /// <summary>
    /// Bonus change
    /// </summary>
    public decimal? BonusChange { get; set; }

    /// <summary>
    /// Trade id
    /// </summary>
    public string TradeId { get; set; }

    /// <summary>
    /// Order id
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// Client order id
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}
