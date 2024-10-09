namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit order update
/// </summary>
public class BybitOrderUpdate
{
    /// <summary>
    /// Product type
    /// Unified account: spot, linear, inverse, option
    /// Classic account: spot, linear, inverse.
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Order Id
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// Client Order Id
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
    
    /// <summary>
    /// Whether to borrow. Unified spot only. 0: false, 1: true. Classic spot is not supported, always 0
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsLeverage { get; set; }

    /// <summary>
    /// Block Trade Id
    /// </summary>
    public string BlockTradeId { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Order Price
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Order Quantity
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Order Side
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Position index. Used to identify positions in different position modes.
    /// </summary>
    [JsonProperty("positionIdx")]
    public BybitPositionIndex? PositionIndex { get; set; }

    /// <summary>
    /// Order status
    /// </summary>
    public BybitOrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Order create type
    /// Only for category=linear or inverse
    /// Spot, Option do not have this key
    /// </summary>
    [JsonProperty("createType")]
    public string CreateType { get; set; } // TODO: Make this field an enum

    /// <summary>
    /// Order Cancel Type
    /// </summary>
    public BybitOrderCancelType? CancelType { get; set; }

    /// <summary>
    /// Reject reason. Classic spot is not supported
    /// </summary>
    public BybitOrderRejectReason RejectReason { get; set; }

    /// <summary>
    /// Average filled price
    /// UTA: returns "" for those orders without avg price
    /// Classic account: returns "0" for those orders without avg price, and also for those orders have partilly filled but cancelled at the end
    /// </summary>
    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    /// <summary>
    /// The remaining qty not executed. Classic spot is not supported
    /// </summary>
    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    /// <summary>
    /// The estimated value not executed. Classic spot is not supported
    /// </summary>
    [JsonProperty("leavesValue")]
    public decimal? RemainingValue { get; set; }

    /// <summary>
    /// Cumulative executed order qty
    /// </summary>
    [JsonProperty("cumExecQty")]
    public decimal? CumulativeExecutedQuantity { get; set; }

    /// <summary>
    /// Cumulative executed order value. Classic spot is not supported
    /// </summary>
    [JsonProperty("cumExecValue")]
    public decimal? CumulativeExecutedValue { get; set; }

    /// <summary>
    /// Cumulative executed trading fee. Classic spot is not supported
    /// </summary>
    [JsonProperty("cumExecFee")]
    public decimal? CumulativeExecutedFee { get; set; }
    
    /// <summary>
    /// Trading fee currency for Spot only. Please understand Spot trading fee currency here
    /// </summary>
    [JsonProperty("feeCurrency")]
    public string FeeCurrency { get; set; }

    /// <summary>
    /// Time in force
    /// </summary>
    public BybitTimeInForce TimeInForce { get; set; }

    /// <summary>
    /// Order type. Market,Limit. For TP/SL order, it means the order type after triggered
    /// </summary>
    [JsonProperty("orderType")]
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Stop order type
    /// </summary>
    [JsonProperty("stopOrderType")]
    public BybitOrderStopType? StopOrderType { get; set; }
    
    /// <summary>
    /// The trigger type of Spot OCO order.OcoTriggerByUnknown, OcoTriggerByTp, OcoTriggerByBySl. Classic spot is not supported
    /// </summary>
    [JsonProperty("ocoTriggerBy")]
    public BybitOcoTriggerBy? OcoTriggerBy { get; set; }

    /// <summary>
    /// Implied volatility
    /// </summary>
    [JsonProperty("orderIv")]
    public decimal? ImpliedVolatility { get; set; }

    /// <summary>
    /// The unit for qty when create Spot market orders for UTA account. baseCoin, quoteCoin
    /// </summary>
    [JsonProperty("marketUnit")]
    public BybitMarketUnit? MarketUnit { get; set; }

    /// <summary>
    /// Trigger price. If stopOrderType=TrailingStop, it is activate price. Otherwise, it is trigger price
    /// </summary>
    [JsonProperty("triggerPrice")]
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Take profit price
    /// </summary>
    [JsonProperty("takeProfit")]
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Stop loss price
    /// </summary>
    [JsonProperty("stopLoss")]
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// TP/SL mode, Full: entire position for TP/SL. Partial: partial position tp/sl. Spot does not have this field, and Option returns always ""
    /// </summary>
    [JsonProperty("tpslMode")]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// The limit order price when take profit price is triggered
    /// </summary>
    [JsonProperty("tpLimitPrice")]
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// The limit order price when stop loss price is triggered
    /// </summary>
    [JsonProperty("slLimitPrice")]
    public decimal? StopLossLimitPrice { get; set; }

    /// <summary>
    /// The price type to trigger take profit
    /// </summary>
    [JsonProperty("tpTriggerBy")]
    public BybitTriggerPrice? TakeProfitTriggerBy { get; set; }

    /// <summary>
    /// The price type to trigger stop loss
    /// </summary>
    [JsonProperty("slTriggerBy")]
    public BybitTriggerPrice? StopLossTriggerBy { get; set; }

    /// <summary>
    /// Trigger direction. 1: rise, 2: fall
    /// </summary>
    [JsonProperty("triggerDirection")]
    public BybitTriggerDirection? TriggerDirection { get; set; }

    /// <summary>
    /// The price type of trigger price
    /// </summary>
    [JsonProperty("triggerBy")]
    public BybitTriggerPrice? TriggerBy { get; set; }

    /// <summary>
    /// Last price when place the order
    /// </summary>
    public decimal? LastPriceOnCreated { get; set; }

    /// <summary>
    /// Reduce only. true means reduce position size
    /// </summary>
    public bool? ReduceOnly { get; set; }

    /// <summary>
    /// Close on trigger. What is a close on trigger order?
    /// </summary>
    public bool? CloseOnTrigger { get; set; }

    /// <summary>
    /// Place type, option used. iv, price
    /// </summary>
    [JsonProperty("placeType")]
    public BybitOptionPlaceType? OptionPlaceType { get; set; }

    /// <summary>
    /// SMP execution type
    /// </summary>
    [JsonProperty("smpType")]
    public BybitSelfMatchPrevention SelfMatchPrevention { get; set; }

    /// <summary>
    /// Smp group ID. If the UID has no group, it is 0 by default
    /// </summary>
    [JsonProperty("smpGroup")]
    public long SelfMatchPreventionGroup { get; set; }

    /// <summary>
    /// The counterparty's orderID which triggers this SMP execution
    /// </summary>
    [JsonProperty("smpOrderId")]
    public string SelfMatchPreventionOrderId { get; set; }

    /// <summary>
    /// Order created timestamp (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Order created time
    /// </summary>
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Order updated timestamp (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdatedTimestamp { get; set; }

    /// <summary>
    /// Order updated time
    /// </summary>
    public DateTime UpdatedTime { get => UpdatedTimestamp.ConvertFromMilliseconds(); }
}