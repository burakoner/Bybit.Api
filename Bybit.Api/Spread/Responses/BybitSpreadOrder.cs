namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread order.
/// </summary>
public record BybitSpreadOrder
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Base asset.
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitOrderType OrderType { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Time in force.
    /// </summary>
    public BybitTimeInForce TimeInForce { get; set; }

    /// <summary>
    /// Spread combination order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Remaining quantity.
    /// </summary>
    [JsonProperty("leavesQty")]
    public decimal? RemainingQuantity { get; set; }

    /// <summary>
    /// Order status.
    /// </summary>
    public BybitOrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Cumulative executed quantity.
    /// </summary>
    [JsonProperty("cumExecQty")]
    public decimal? CumulativeExecutedQuantity { get; set; }

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
    /// Original order quantity returned by order history.
    /// </summary>
    [JsonProperty("orderQty")]
    public decimal? OrderQuantity { get; set; }

    /// <summary>
    /// Created timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Created timestamp alias returned by order history.
    /// </summary>
    [JsonProperty("createdAt")]
    protected long CreatedAtTimestamp { set => CreatedTimestamp = value; get => CreatedTimestamp; }

    /// <summary>
    /// Created time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Updated timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdatedTimestamp { get; set; }

    /// <summary>
    /// Updated timestamp alias returned by order history.
    /// </summary>
    [JsonProperty("updatedAt")]
    protected long UpdatedAtTimestamp { set => UpdatedTimestamp = value; get => UpdatedTimestamp; }

    /// <summary>
    /// Updated time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdatedTime { get => UpdatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Spread contract type.
    /// </summary>
    public BybitSpreadContractType? ContractType { get; set; }

    /// <summary>
    /// Cancel reject reason.
    /// </summary>
    [JsonProperty("cxlRejReason")]
    public string CancelRejectReason { get; set; } = string.Empty;

    /// <summary>
    /// Settle asset.
    /// </summary>
    [JsonProperty("settleCoin")]
    public string SettleAsset { get; set; } = string.Empty;

    /// <summary>
    /// First leg symbol.
    /// </summary>
    public string Leg1Symbol { get; set; } = string.Empty;

    /// <summary>
    /// First leg product type.
    /// </summary>
    public BybitSpreadLegProductType? Leg1ProdType { get; set; }

    /// <summary>
    /// First leg order ID.
    /// </summary>
    public string Leg1OrderId { get; set; } = string.Empty;

    /// <summary>
    /// First leg side.
    /// </summary>
    public BybitOrderSide? Leg1Side { get; set; }

    /// <summary>
    /// Second leg product type.
    /// </summary>
    public BybitSpreadLegProductType? Leg2ProdType { get; set; }

    /// <summary>
    /// Second leg order ID.
    /// </summary>
    public string Leg2OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Second leg symbol.
    /// </summary>
    public string Leg2Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Second leg side.
    /// </summary>
    public BybitOrderSide? Leg2Side { get; set; }
}
