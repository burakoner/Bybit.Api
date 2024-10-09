namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Trigger Price
/// </summary>
public enum BybitTriggerPrice
{
    /// <summary>
    /// Last Price
    /// </summary>
    [Map("LastPrice")]
    LastPrice = 1,

    /// <summary>
    /// Index Price
    /// </summary>
    [Map("IndexPrice")]
    IndexPrice = 2,

    /// <summary>
    /// Mark Price
    /// </summary>
    [Map("MarkPrice")]
    MarkPrice = 3,
}