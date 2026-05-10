namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade order history item.
/// </summary>
public record BybitPreUpgradeOrder
{
    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Block trade ID.
    /// </summary>
    public string BlockTradeId { get; set; } = string.Empty;

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

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
    /// Order side.
    /// </summary>
    public BybitOrderSide? Side { get; set; }

    /// <summary>
    /// Historical isLeverage value. Bybit documents this as a useless string for pre-upgrade orders.
    /// </summary>
    public string IsLeverage { get; set; } = string.Empty;

    /// <summary>
    /// Position index.
    /// </summary>
    [JsonProperty("positionIdx")]
    public BybitPositionIndex? PositionIndex { get; set; }

    /// <summary>
    /// Order status.
    /// </summary>
    public BybitOrderStatus? OrderStatus { get; set; }

    /// <summary>
    /// Cancel type.
    /// </summary>
    public string CancelType { get; set; } = string.Empty;

    /// <summary>
    /// Reject reason.
    /// </summary>
    public string RejectReason { get; set; } = string.Empty;

    /// <summary>
    /// Average filled price.
    /// </summary>
    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    /// <summary>
    /// Remaining quantity not executed.
    /// </summary>
    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    /// <summary>
    /// Estimated remaining value not executed.
    /// </summary>
    [JsonProperty("leavesValue")]
    public decimal? RemainingValue { get; set; }

    /// <summary>
    /// Cumulative executed order quantity.
    /// </summary>
    [JsonProperty("cumExecQty")]
    public decimal? CumulativeExecutedQuantity { get; set; }

    /// <summary>
    /// Cumulative executed order value.
    /// </summary>
    [JsonProperty("cumExecValue")]
    public decimal? CumulativeExecutedValue { get; set; }

    /// <summary>
    /// Cumulative executed trading fee.
    /// </summary>
    [JsonProperty("cumExecFee")]
    public decimal? CumulativeExecutedFee { get; set; }

    /// <summary>
    /// Time in force.
    /// </summary>
    public BybitTimeInForce? TimeInForce { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType? OrderType { get; set; }

    /// <summary>
    /// Stop order type.
    /// </summary>
    public BybitOrderStopType? StopOrderType { get; set; }

    /// <summary>
    /// Implied volatility.
    /// </summary>
    [JsonProperty("orderIv")]
    public decimal? ImpliedVolatility { get; set; }

    /// <summary>
    /// Trigger price.
    /// </summary>
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Take profit price.
    /// </summary>
    [JsonProperty("takeProfit")]
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Stop loss price.
    /// </summary>
    [JsonProperty("stopLoss")]
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// Take profit trigger price type.
    /// </summary>
    [JsonProperty("tpTriggerBy")]
    public BybitTriggerPrice? TakeProfitTriggerBy { get; set; }

    /// <summary>
    /// Stop loss trigger price type.
    /// </summary>
    [JsonProperty("slTriggerBy")]
    public BybitTriggerPrice? StopLossTriggerBy { get; set; }

    /// <summary>
    /// Trigger direction.
    /// </summary>
    public int? TriggerDirection { get; set; }

    /// <summary>
    /// Trigger price type.
    /// </summary>
    public BybitTriggerPrice? TriggerBy { get; set; }

    /// <summary>
    /// Last price when the order was placed.
    /// </summary>
    public decimal? LastPriceOnCreated { get; set; }

    /// <summary>
    /// Reduce-only flag.
    /// </summary>
    public bool? ReduceOnly { get; set; }

    /// <summary>
    /// Close-on-trigger flag.
    /// </summary>
    public bool? CloseOnTrigger { get; set; }

    /// <summary>
    /// Option place type.
    /// </summary>
    [JsonProperty("placeType")]
    public BybitOptionPlaceType? OptionPlaceType { get; set; }

    /// <summary>
    /// SMP execution type.
    /// </summary>
    [JsonProperty("smpType")]
    public BybitSelfMatchPrevention? SelfMatchPrevention { get; set; }

    /// <summary>
    /// SMP group ID.
    /// </summary>
    [JsonProperty("smpGroup")]
    public long SelfMatchPreventionGroup { get; set; }

    /// <summary>
    /// Counterparty order ID that triggered SMP execution.
    /// </summary>
    [JsonProperty("smpOrderId")]
    public string SelfMatchPreventionOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order created timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Order created time.
    /// </summary>
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Order updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdatedTimestamp { get; set; }

    /// <summary>
    /// Order updated time.
    /// </summary>
    public DateTime UpdatedTime { get => UpdatedTimestamp.ConvertFromMilliseconds(); }
}
