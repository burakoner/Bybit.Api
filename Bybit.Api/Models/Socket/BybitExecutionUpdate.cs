namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit execution update
/// </summary>
public class BybitExecutionUpdate
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; }
    
    /// <summary>
    /// Whether to borrow. Unified spot only. 0: false, 1: true. . Classic spot is not supported, always 0
    /// </summary>
    [JsonProperty("isLeverage"), JsonConverter(typeof(BooleanConverter))]
    public bool IsLeverage { get; set; }
    
    /// <summary>
    /// Order ID
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// User customized order ID. Classic spot is not supported
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
    
    /// <summary>
    /// Side. Buy,Sell
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order price
    /// </summary>
    public decimal? OrderPrice { get; set; }

    /// <summary>
    /// Order quantity
    /// </summary>
    [JsonProperty("orderQty")]
    public decimal? OrderQuantity { get; set; }
    
    /// <summary>
    /// The remaining qty not executed. Classic spot is not supported
    /// </summary>
    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }
    
    /// <summary>
    /// Order create type
    /// UTA: Only for category=linear or inverse
    /// Classic: always ""
    /// Spot, Option do not have this key
    /// </summary>
    [JsonProperty("createType")]
    public string CreateType { get; set; } // TODO: Make this field an enum
    
    /// <summary>
    /// Order Type
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderType>))]
    public BybitOrderType? OrderType { get; set; }

    /// <summary>
    /// Stop order type
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderStopType>))]
    public BybitOrderStopType? StopOrderType { get; set; }
    
    /// <summary>
    /// Executed trading fee. You can get spot fee currency instruction here
    /// </summary>
    [JsonProperty("execFee")]
    public decimal? Fee { get; set; }

    /// <summary>
    /// Execution ID
    /// </summary>
    [JsonProperty("execId")]
    public string TradeId { get; set; }

    /// <summary>
    /// Execution Price
    /// </summary>
    [JsonProperty("execPrice")]
    public decimal Price { get; set; }

    /// <summary>
    /// Execution Quantity
    /// </summary>
    [JsonProperty("execQty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Execution Type
    /// </summary>
    [JsonProperty("execType"), JsonConverter(typeof(LabelConverter<BybitExecutionType>))]
    public BybitExecutionType? ExecutionType { get; set; }

    /// <summary>
    /// Execution Value
    /// </summary>
    [JsonProperty("execValue")]
    public decimal? Value { get; set; }

    /// <summary>
    /// Execution Time
    /// </summary>
    [JsonProperty("execTime")]
    public long Timestamp { get; set; }

    /// <summary>
    /// Execution Time
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
    
    /// <summary>
    /// Is maker order. true: maker, false: taker
    /// </summary>
    public bool IsMaker { get; set; }

    /// <summary>
    /// Trading fee rate. Classic spot is not supported
    /// </summary>
    public decimal? FeeRate { get; set; }

    /// <summary>
    /// Implied volatility. Valid for option
    /// </summary>
    public decimal? TradeIv { get; set; }

    /// <summary>
    /// Implied volatility of mark price. Valid for option
    /// </summary>
    public decimal? MarkIv { get; set; }

    /// <summary>
    /// The mark price of the symbol when executing. Classic spot is not supported
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// The index price of the symbol when executing. Valid for option only
    /// </summary>
    public decimal? IndexPrice { get; set; }

    /// <summary>
    /// The underlying price of the symbol when executing. Valid for option
    /// </summary>
    public decimal? UnderlyingPrice { get; set; }

    /// <summary>
    /// Paradigm block trade ID
    /// </summary>
    public string BlockTradeId { get; set; }

    /// <summary>
    /// Closed position size
    /// </summary>
    [JsonProperty("closedSize")]
    public decimal? ClosedQuantity { get; set; }

    /// <summary>
    /// Cross sequence, used to associate each fill and each position update
    /// The seq will be the same when conclude multiple transactions at the same time
    /// Different symbols may have the same seq, please use seq + symbol to check unique
    /// Classic account Spot trade does not have this field
    /// </summary>
    [JsonProperty("seq")]
    public long? Sequence { get; set; }
}