namespace Bybit.Api.System;

/// <summary>
/// Bybit System State
/// </summary>
public enum BybitSystemState
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("0")]
    Unknown = 0,

    /// <summary>
    /// Scheduled
    /// </summary>
    [Map("1")]
    Scheduled = 1,

    /// <summary>
    /// Ongoing
    /// </summary>
    [Map("2")]
    Ongoing = 2,

    /// <summary>
    /// Completed
    /// </summary>
    [Map("3")]
    Completed = 3,

    /// <summary>
    /// Canceled
    /// </summary>
    [Map("4")]
    Canceled = 4,
}