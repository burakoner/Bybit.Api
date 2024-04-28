namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Filter
/// </summary>
public enum BybitOrderFilter
{
    /// <summary>
    /// Order
    /// </summary>
    [Label("Order")]
    Order,

    /// <summary>
    /// Take Profit Stop Loss Order
    /// </summary>
    [Label("tpslOrder")]
    TakeProfitStopLossOrder,

    /// <summary>
    /// Stop Order
    /// </summary>
    [Label("StopOrder")]
    StopOrder,

    /// <summary>
    /// OCO Order
    /// </summary>
    [Label("OcoOrder")]
    OcoOrder,

    /// <summary>
    /// Bidirectional Take Profit Stop Loss Order
    /// </summary>
    [Label("BidirectionalTpslOrder")]
    BidirectionalTpslOrder,
}