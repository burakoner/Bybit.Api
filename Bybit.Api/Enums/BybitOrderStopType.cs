namespace Bybit.Api.Enums;

/// <summary>
/// BybitOrderStopType
/// </summary>
public enum BybitOrderStopType
{
    /// <summary>
    /// TakeProfit
    /// </summary>
    [Map("TakeProfit")]
    TakeProfit = 1,

    /// <summary>
    /// StopLoss
    /// </summary>
    [Map("StopLoss")]
    StopLoss = 2,

    /// <summary>
    /// TrailingStop
    /// </summary>
    [Map("TrailingStop")]
    TrailingStop = 3,

    /// <summary>
    /// Stop
    /// </summary>
    [Map("Stop")]
    Stop = 4,

    /// <summary>
    /// PartialTakeProfit
    /// </summary>
    [Map("PartialTakeProfit")]
    PartialTakeProfit = 5,

    /// <summary>
    /// PartialStopLoss
    /// </summary>
    [Map("PartialStopLoss")]
    PartialStopLoss = 6,

    /// <summary>
    /// TakeProfitStopLossOrder
    /// </summary>
    [Map("tpslOrder")]
    TakeProfitStopLossOrder = 7,
}