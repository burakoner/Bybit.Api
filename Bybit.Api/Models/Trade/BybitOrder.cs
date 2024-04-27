namespace Bybit.Api.Models.Trade;

public class BybitOrder
{
    public string OrderId { get; set; }
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
    public string BlockTradeId { get; set; }
    public string Symbol { get; set; }
    public decimal? Price { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsLeverage { get; set; }

    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide? Side { get; set; }

    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex? PositionIndex { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderStatus>))]
    public BybitOrderStatus? OrderStatus { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderCancelType>))]
    public BybitOrderCancelType? CancelType { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderRejectReason>))]
    public BybitOrderRejectReason? rejectReason { get; set; }

    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    [JsonProperty("leavesValue")]
    public decimal? RemainingValue { get; set; }

    [JsonProperty("cumExecQty")]
    public decimal? CumulativeExecutedQuantity { get; set; }

    [JsonProperty("cumExecValue")]
    public decimal? CumulativeExecutedValue { get; set; }

    [JsonProperty("cumExecFee")]
    public decimal? CumulativeExecutedFee { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitTimeInForce>))]
    public BybitTimeInForce? TimeInForce { get; set; }

    [JsonProperty("orderType"), JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType? OrderType { get; set; }

    [JsonProperty("stopOrderType"), JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderStopType? StopOrderType { get; set; }

    [JsonProperty("orderIv")]
    public decimal? ImpliedVolatility { get; set; }

    [JsonProperty("triggerPrice")]
    public decimal? TriggerPrice { get; set; }

    [JsonProperty("takeProfit")]
    public decimal? TakeProfitPrice { get; set; }

    [JsonProperty("stopLoss")]
    public decimal? StopLossPrice { get; set; }

    [JsonProperty("triggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? TriggerBy { get; set; }

    [JsonProperty("tpTriggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? TakeProfitTriggerBy { get; set; }

    [JsonProperty("slTriggerBy"), JsonConverter(typeof(LabelConverter<BybitTriggerPrice>))]
    public BybitTriggerPrice? StopLossTriggerBy { get; set; }

    [JsonProperty("triggerDirection"), JsonConverter(typeof(LabelConverter<BybitTriggerDirection>))]
    public BybitTriggerDirection? TriggerDirection { get; set; }

    [JsonProperty("placeType"), JsonConverter(typeof(LabelConverter<BybitOptionPlaceType>))]
    public BybitOptionPlaceType? OptionPlaceType { get; set; }

    public decimal? LastPriceOnCreated { get; set; }
    public bool? ReduceOnly { get; set; }
    public bool? CloseOnTrigger { get; set; }

    [JsonProperty("createdTime")]
    public long? CreatedTimestamp { get; set; }
    public DateTime? CreatedTime { get => CreatedTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("updatedTime")]
    public long? UpdatedTimestamp { get; set; }
    public DateTime? UpdatedTime { get => UpdatedTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("smpType"), JsonConverter(typeof(LabelConverter<BybitSelfMatchPrevention>))]
    public BybitSelfMatchPrevention? SelfMatchPrevention { get; set; }
    [JsonProperty("smpGroup")]
    public long? SelfMatchGroup { get; set; }
    [JsonProperty("smpOrderId")]
    public string SelfMatchOrderId { get; set; }
}
