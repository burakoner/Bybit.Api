namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Filter
/// </summary>
public enum BybitOrderFilter
{
    /// <summary>
    /// Order
    /// </summary>
    [Map("Order")]
    Order = 1,

    /// <summary>
    /// Take Profit Stop Loss Order
    /// </summary>
    [Map("tpslOrder")]
    TakeProfitStopLossOrder = 2,

    /// <summary>
    /// Stop Order
    /// </summary>
    [Map("StopOrder")]
    StopOrder = 3,

    /// <summary>
    /// OCO Order
    /// </summary>
    [Map("OcoOrder")]
    OcoOrder = 4,

    /// <summary>
    /// Bidirectional Take Profit Stop Loss Order
    /// </summary>
    [Map("BidirectionalTpslOrder")]
    BidirectionalTpSlOrder = 5,
}