namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread order stream update.
/// </summary>
public record BybitSpreadOrderUpdate
{
    /// <summary>
    /// Category name: combination, spot_leg or future_leg.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Combo or leg symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Leg parent order ID.
    /// </summary>
    public string ParentOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Combo or leg order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Combo user customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order status.
    /// </summary>
    public BybitOrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Cancel type.
    /// </summary>
    public string CancelType { get; set; } = string.Empty;

    /// <summary>
    /// Reject reason.
    /// </summary>
    public string RejectReason { get; set; } = string.Empty;

    /// <summary>
    /// Time in force.
    /// </summary>
    public BybitTimeInForce TimeInForce { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Average filled price.
    /// </summary>
    public decimal? AvgPrice { get; set; }

    /// <summary>
    /// Remaining quantity.
    /// </summary>
    public decimal? LeavesQty { get; set; }

    /// <summary>
    /// Estimated remaining value.
    /// </summary>
    public decimal? LeavesValue { get; set; }

    /// <summary>
    /// Cumulative executed quantity.
    /// </summary>
    public decimal? CumExecQty { get; set; }

    /// <summary>
    /// Cumulative executed value.
    /// </summary>
    public decimal? CumExecValue { get; set; }

    /// <summary>
    /// Deprecated cumulative executed fee.
    /// </summary>
    public decimal? CumExecFee { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Whether to borrow for the spot leg.
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsLeverage { get; set; }

    /// <summary>
    /// Order created timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Order created time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Order updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdatedTimestamp { get; set; }

    /// <summary>
    /// Order updated time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdatedTime { get => UpdatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Deprecated trading fee currency.
    /// </summary>
    public string FeeCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Order create type.
    /// </summary>
    public string CreateType { get; set; } = string.Empty;

    /// <summary>
    /// Closed profit and loss for each close position order.
    /// </summary>
    public decimal? ClosedPnl { get; set; }

    /// <summary>
    /// Cumulative trading fee details. Bybit can return an object or an empty string.
    /// </summary>
    public JToken? CumFeeDetail { get; set; }
}
