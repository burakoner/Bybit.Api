namespace Bybit.Api.Sbe;

/// <summary>
/// SBE create order request.
/// </summary>
public record BybitSbeCreateOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeCreateOrderRequest"/> record.
    /// </summary>
    public BybitSbeCreateOrderRequest(BybitSbeCategory category, long symbolId, BybitSbeSide side, BybitSbeOrderType orderType, BybitSbeDecimal64 quantity, BybitSbeDecimal64 price, string orderLinkId)
    {
        Category = category;
        SymbolId = symbolId;
        Side = side;
        OrderType = orderType;
        Quantity = quantity;
        Price = price;
        OrderLinkId = orderLinkId;
    }

    /// <summary>
    /// API request header.
    /// </summary>
    public BybitSbeApiRequestHeader Header { get; set; } = new();

    /// <summary>
    /// Product category.
    /// </summary>
    public BybitSbeCategory Category { get; set; }

    /// <summary>
    /// Internal numeric symbol ID.
    /// </summary>
    public long SymbolId { get; set; }

    /// <summary>
    /// Order side.
    /// </summary>
    public BybitSbeSide Side { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    public BybitSbeOrderType OrderType { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    public BybitSbeDecimal64 Quantity { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    public BybitSbeDecimal64 Price { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    public string OrderLinkId { get; set; }

    /// <summary>
    /// Time in force.
    /// </summary>
    public BybitSbeTimeInForce TimeInForce { get; set; } = BybitSbeTimeInForce.GoodTillCancel;

    /// <summary>
    /// Position index.
    /// </summary>
    public BybitSbePositionIndex PositionIndex { get; set; } = BybitSbePositionIndex.OneWay;

    /// <summary>
    /// Market unit.
    /// </summary>
    public BybitSbeMarketUnit MarketUnit { get; set; } = BybitSbeMarketUnit.BaseCoin;

    /// <summary>
    /// Whether leverage is used.
    /// </summary>
    public BybitSbeBool IsLeverage { get; set; } = BybitSbeBool.False;

    /// <summary>
    /// Whether order is reduce-only.
    /// </summary>
    public BybitSbeBool ReduceOnly { get; set; } = BybitSbeBool.False;

    /// <summary>
    /// Whether order closes on trigger.
    /// </summary>
    public BybitSbeBool CloseOnTrigger { get; set; } = BybitSbeBool.False;

    /// <summary>
    /// Whether market maker protection is enabled.
    /// </summary>
    public BybitSbeBool MarketMakerProtection { get; set; } = BybitSbeBool.False;

    /// <summary>
    /// Self-match prevention type.
    /// </summary>
    public BybitSbeSelfMatchPrevention SelfMatchPrevention { get; set; } = BybitSbeSelfMatchPrevention.Unknown;
}
