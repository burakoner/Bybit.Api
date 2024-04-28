namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Stop Order Type
/// </summary>
public enum BybitStopOrderType
{
    /// <summary>
    /// Take Profit
    /// </summary>
    [Label("TakeProfit")]
    TakeProfit,

    /// <summary>
    /// Stop Loss
    /// </summary>
    [Label("StopLoss")]
    StopLoss,

    /// <summary>
    /// Trailing Stop
    /// </summary>
    [Label("TrailingStop")]
    TrailingStop,

    /// <summary>
    /// Stop
    /// </summary>
    [Label("Stop")]
    Stop,

    /// <summary>
    /// Partial Take Profit
    /// </summary>
    [Label("PartialTakeProfit")]
    PartialTakeProfit,

    /// <summary>
    /// Partial Stop Loss
    /// </summary>
    [Label("PartialStopLoss")]
    PartialStopLoss,

    /// <summary>
    /// Take Profit and Stop Loss
    /// </summary>
    [Label("tpslOrder")]
    tpslOrder,

    /// <summary>
    /// OCO Order
    /// </summary>
    [Label("OcoOrder")]
    OcoOrder,

    /// <summary>
    /// On web or app can set MMR to close position
    /// </summary>
    [Label("MmRateClose")]
    MmRateClose,

    /// <summary>
    /// Spot bidirectional tpsl order
    /// </summary>
    [Label("BidirectionalTpslOrder")]
    BidirectionalTpslOrder,
}