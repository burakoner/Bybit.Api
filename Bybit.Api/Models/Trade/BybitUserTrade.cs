namespace Bybit.Api.Models.Trade;

public class BybitUserTrade
{
    public string Symbol { get; set; }
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    public decimal? OrderPrice { get; set; }

    [JsonProperty("orderQty")]
    public decimal? OrderQuantity { get; set; }

    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType? OrderType { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderStopType? StopOrderType { get; set; }

    [JsonProperty("execFee")]
    public decimal? Fee { get; set; }
    public decimal? FeeRate { get; set; }

    [JsonProperty("execId")]
    public string TradeId { get; set; }

    [JsonProperty("execPrice")]
    public decimal Price { get; set; }

    [JsonProperty("execQty")]
    public decimal Quantity { get; set; }

    [JsonProperty("execType"), JsonConverter(typeof(LabelConverter<BybitExecutionType>))]
    public BybitExecutionType? ExecutionType { get; set; }

    [JsonProperty("execValue")]
    public decimal? Value { get; set; }

    [JsonProperty("execTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    public bool IsMaker { get; set; }

    public decimal? TradeIv { get; set; }
    public decimal? MarkIv { get; set; }
    public decimal? MarkPrice { get; set; }
    public decimal? IndexPrice { get; set; }
    public decimal? UnderlyingPrice { get; set; }
    public string BlockTradeId { get; set; }

    [JsonProperty("closedSize")]
    public decimal? ClosedQuantity { get; set; }
}
