namespace Bybit.Api.Enums;

/// <summary>
/// Bybit OCO Trigger By
/// </summary>
public enum BybitOcoTriggerBy
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Label("OcoTriggerByUnknown")]
    Unknown,
    
    /// <summary>
    /// Take Profit
    /// </summary>
    [Label("OcoTriggerByTp")]
    TakeProfit,

    /// <summary>
    /// Stop Loss
    /// </summary>
    [Label("OcoTriggerByBySl")]
    StopLoss,
}