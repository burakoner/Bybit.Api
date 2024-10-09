namespace Bybit.Api.Enums;

/// <summary>
/// Bybit OCO Trigger By
/// </summary>
public enum BybitOcoTriggerBy
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("OcoTriggerByUnknown")]
    Unknown = 0,

    /// <summary>
    /// Take Profit
    /// </summary>
    [Map("OcoTriggerByTp")]
    TakeProfit = 1,

    /// <summary>
    /// Stop Loss
    /// </summary>
    [Map("OcoTriggerByBySl")]
    StopLoss = 2,
}