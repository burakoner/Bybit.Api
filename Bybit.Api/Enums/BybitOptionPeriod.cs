namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Option Period
/// </summary>
public enum BybitOptionPeriod
{
    /// <summary>
    /// 7 Days
    /// </summary>
    [Label("7")]
    SevenDays,

    /// <summary>
    /// 14 Days
    /// </summary>
    [Label("14")]
    FourteenDays,

    /// <summary>
    /// 21 Days
    /// </summary>
    [Label("21")]
    TwentyOneDays,

    /// <summary>
    /// 30 Days
    /// </summary>
    [Label("30")]
    ThirtyDays,

    /// <summary>
    /// 60 Days
    /// </summary>
    [Label("60")]
    SixtyDays,

    /// <summary>
    /// 90 Days
    /// </summary>
    [Label("90")]
    NinetyDays,

    /// <summary>
    /// 180 Days
    /// </summary>
    [Label("180")]
    HundredAndEightyDays,

    /// <summary>
    /// 270 Days
    /// </summary>
    [Label("270")]
    TwoHundredAndSeventyDays,
}