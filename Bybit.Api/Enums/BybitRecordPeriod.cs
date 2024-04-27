namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Record Interval
/// </summary>
public enum BybitRecordPeriod
{
    /// <summary>
    /// Five Minutes
    /// </summary>
    [Label("5min")]
    FiveMinutes,

    /// <summary>
    /// Fifteen Minutes
    /// </summary>
    [Label("15min")]
    FifteenMinutes,

    /// <summary>
    /// Thirty Minutes
    /// </summary>
    [Label("30min")]
    ThirtyMinutes,

    /// <summary>
    /// One Hour
    /// </summary>
    [Label("1h")]
    OneHour,

    /// <summary>
    /// Four Hours
    /// </summary>
    [Label("4h")]
    FourHours,

    /// <summary>
    /// One Day
    /// </summary>
    [Label("1d")]
    OneDay,
}