namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Trigger Price
/// </summary>
public enum BybitTriggerPrice
{
    /// <summary>
    /// Last Price
    /// </summary>
    [Label("LastPrice")]
    LastPrice,

    /// <summary>
    /// Index Price
    /// </summary>
    [Label("IndexPrice")]
    IndexPrice,

    /// <summary>
    /// Mark Price
    /// </summary>
    [Label("MarkPrice")]
    MarkPrice,
}