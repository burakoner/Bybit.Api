namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Stop Order Type
/// </summary>
public enum BybitStopOrderType
{
    /// <summary>
    /// Take Profit
    /// </summary>
    [Map("TakeProfit")]
    TakeProfit = 1,

    /// <summary>
    /// Stop Loss
    /// </summary>
    [Map("StopLoss")]
    StopLoss = 2,

    /// <summary>
    /// Trailing Stop
    /// </summary>
    [Map("TrailingStop")]
    TrailingStop = 3,

    /// <summary>
    /// Stop
    /// </summary>
    [Map("Stop")]
    Stop = 4,

    /// <summary>
    /// Partial Take Profit
    /// </summary>
    [Map("PartialTakeProfit")]
    PartialTakeProfit = 5,

    /// <summary>
    /// Partial Stop Loss
    /// </summary>
    [Map("PartialStopLoss")]
    PartialStopLoss = 6,

    /// <summary>
    /// Take Profit and Stop Loss
    /// </summary>
    [Map("tpslOrder")]
    tpslOrder = 7,

    /// <summary>
    /// OCO Order
    /// </summary>
    [Map("OcoOrder")]
    OcoOrder = 8,

    /// <summary>
    /// On web or app can set MMR to close position
    /// </summary>
    [Map("MmRateClose")]
    MmRateClose = 9,

    /// <summary>
    /// Spot bidirectional tpsl order
    /// </summary>
    [Map("BidirectionalTpslOrder")]
    BidirectionalTpslOrder = 10,
}