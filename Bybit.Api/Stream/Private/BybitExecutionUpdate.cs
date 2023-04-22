namespace Bybit.Api.Helpers.Private;

public class BybitExecutionUpdate
{
    public string Symbol { get; set; }

    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory? Category { get; set; }

    [JsonProperty("isLeverage"), JsonConverter(typeof(BooleanConverter))]
    public bool? IsLeverage { get; set; }

    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide? Side { get; set; }

    [JsonProperty("orderPrice")]
    public decimal? OrderPrice { get; set; }

    [JsonProperty("orderQty")]
    public decimal? OrderQuantity { get; set; }

    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    [JsonProperty("orderType"), JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType? OrderType { get; set; }

    [JsonProperty("stopOrderType"), JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderStopType? OrderStopType { get; set; }

    [JsonProperty("execFee")]
    public decimal? ExecutionFee { get; set; }

    [JsonProperty("execId")]
    public string ExecutionId { get; set; }

    [JsonProperty("execPrice")]
    public decimal? ExecutionPrice { get; set; }

    [JsonProperty("execQty")]
    public decimal? ExecutionQuantity { get; set; }

    [JsonProperty("execType"), JsonConverter(typeof(LabelConverter<BybitExecutionType>))]
    public BybitExecutionType? ExecutionType { get; set; }

    [JsonProperty("execValue")]
    public decimal? ExecutionValue { get; set; }

    [JsonProperty("execTime")]
    public long? ExecutionTimestamp { get; set; }
    public DateTime? ExecutionTime { get => ExecutionTimestamp?.ConvertFromMilliseconds(); }

    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsMaker { get; set; }
    public decimal? FeeRate { get; set; }
    public decimal? TradeIv { get; set; }
    public decimal? MarkIv { get; set; }
    public decimal? MarkPrice { get; set; }
    public decimal? IndexPrice { get; set; }
    public decimal? UnderlyingPrice { get; set; }
    public string BlockTradeId { get; set; }
    public decimal? ClosedSize { get; set; }
}