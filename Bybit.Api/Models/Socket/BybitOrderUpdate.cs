namespace Bybit.Api.Models.Socket;

public class BybitOrderUpdate
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory? Category { get; set; }

    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }

    [JsonProperty("isLeverage"), JsonConverter(typeof(BooleanConverter))]
    public bool? IsLeverage { get; set; }

    public string BlockTradeId { get; set; }
    public string Symbol { get; set; }
    public decimal? Price { get; set; }

    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide? Side { get; set; }

    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex? PositionIndex { get; set; }

    [JsonProperty("orderStatus"), JsonConverter(typeof(LabelConverter<BybitOrderStatus>))]
    public BybitOrderStatus? OrderStatus { get; set; }

    [JsonProperty("cancelType"), JsonConverter(typeof(LabelConverter<BybitOrderCancelType>))]
    public BybitOrderCancelType? CancelType { get; set; }

    [JsonProperty("rejectReason"), JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderRejectReason? RejectReason { get; set; }

    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    [JsonProperty("leavesValue")]
    public decimal? RemainingValue { get; set; }

    [JsonProperty("cumExecQty")]
    public decimal? CumulativeExecutionQuantity { get; set; }

    [JsonProperty("cumExecValue")]
    public decimal? CumulativeExecutionValue { get; set; }

    [JsonProperty("cumExecFee")]
    public decimal? CumulativeExecutionFee { get; set; }

    [JsonProperty("timeInForce"), JsonConverter(typeof(LabelConverter<BybitTimeInForce>))]
    public BybitTimeInForce? TimeInForce { get; set; }

    [JsonProperty("orderType"), JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType? OrderType { get; set; }

    [JsonProperty("stopOrderType"), JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderStopType? OrderStopType { get; set; }

    public decimal? OrderIv { get; set; }
    public decimal? TriggerPrice { get; set; }
    public decimal? TakeProfit { get; set; }
    public decimal? StopLoss { get; set; }

    [JsonProperty("tpTriggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? TakeProfitTriggerPrice { get; set; }

    [JsonProperty("slTriggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? StopLossTriggerPrice { get; set; }

    [JsonProperty("triggerDirection"), JsonConverter(typeof(LabelConverter<BybitTriggerDirection>))]
    public BybitTriggerDirection? TriggerDirection { get; set; }

    [JsonProperty("triggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? TriggerBy { get; set; }

    public decimal? LastPriceOnCreated { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool? ReduceOnly { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool? CloseOnTrigger { get; set; }

    [JsonProperty("placeType"), JsonConverter(typeof(LabelConverter<BybitOptionPlaceType>))]
    public BybitOptionPlaceType? PlaceType { get; set; }

    [JsonProperty("smpType"), JsonConverter(typeof(LabelConverter<BybitSelfMatchPrevention>))]
    public BybitSelfMatchPrevention? SelfMatchPrevention { get; set; }

    [JsonProperty("smpGroup")]
    public string MatchPreventionGroup { get; set; }

    [JsonProperty("smpOrderId")]
    public string MatchPreventionOrderId { get; set; }

    [JsonProperty("createdTime")]
    public long? CreatedTimestamp { get; set; }
    public DateTime? CreatedTime { get => CreatedTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdatedTimestamp { get; set; }
    public DateTime? UpdatedTime { get => UpdatedTimestamp?.ConvertFromMilliseconds(); }
}