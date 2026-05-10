namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card trade status.
/// </summary>
public enum BybitCardTradeStatus
{
    /// <summary>
    /// In progress.
    /// </summary>
    [Map("0")]
    InProgress = 0,

    /// <summary>
    /// Completed.
    /// </summary>
    [Map("1")]
    Completed = 1,

    /// <summary>
    /// Declined.
    /// </summary>
    [Map("2")]
    Declined = 2,

    /// <summary>
    /// Reversal.
    /// </summary>
    [Map("3")]
    Reversal = 3,
}
