namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Kline Interval
/// </summary>
public enum BybitKlineInterval
{
    /// <summary>
    /// One Minute
    /// </summary>
    [Label("1")]
    OneMinute,

    /// <summary>
    /// Three Minutes
    /// </summary>
    [Label("3")]
    ThreeMinutes,

    /// <summary>
    /// Five Minutes
    /// </summary>
    [Label("5")]
    FiveMinutes,

    /// <summary>
    /// Fifteen Minutes
    /// </summary>
    [Label("15")]
    FifteenMinutes,

    /// <summary>
    /// Thirty Minutes
    /// </summary>
    [Label("30")]
    ThirtyMinutes,

    /// <summary>
    /// One Hour
    /// </summary>
    [Label("60")]
    OneHour,

    /// <summary>
    /// Two Hours
    /// </summary>
    [Label("120")]
    TwoHours,

    /// <summary>
    /// Four Hours
    /// </summary>
    [Label("240")]
    FourHours,

    /// <summary>
    /// Six Hours
    /// </summary>
    [Label("360")]
    SixHours,

    /// <summary>
    /// Twelve Hours
    /// </summary>
    [Label("720")]
    TwelveHours,

    /// <summary>
    /// One Day
    /// </summary>
    [Label("D")]
    OneDay,

    /// <summary>
    /// One Week
    /// </summary>
    [Label("W")]
    OneWeek,

    /// <summary>
    /// One Month
    /// </summary>
    [Label("M")]
    OneMonth,
}