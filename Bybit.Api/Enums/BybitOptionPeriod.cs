namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Option Period
/// </summary>
public enum BybitOptionPeriod
{
    /// <summary>
    /// 7 Days
    /// </summary>
    [Map("7")]
    SevenDays = 7,

    /// <summary>
    /// 14 Days
    /// </summary>
    [Map("14")]
    FourteenDays = 14,

    /// <summary>
    /// 21 Days
    /// </summary>
    [Map("21")]
    TwentyOneDays = 21,

    /// <summary>
    /// 30 Days
    /// </summary>
    [Map("30")]
    ThirtyDays = 30,

    /// <summary>
    /// 60 Days
    /// </summary>
    [Map("60")]
    SixtyDays = 60,

    /// <summary>
    /// 90 Days
    /// </summary>
    [Map("90")]
    NinetyDays = 90,

    /// <summary>
    /// 180 Days
    /// </summary>
    [Map("180")]
    HundredAndEightyDays = 180,

    /// <summary>
    /// 270 Days
    /// </summary>
    [Map("270")]
    TwoHundredAndSeventyDays = 270,
}