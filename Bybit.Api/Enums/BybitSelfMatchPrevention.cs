namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Self Match Prevention
/// </summary>
public enum BybitSelfMatchPrevention
{
    /// <summary>
    /// None
    /// </summary>
    [Map("None")]
    None = 0,

    /// <summary>
    /// Cancel Maker
    /// </summary>
    [Map("CancelMaker")]
    CancelMaker = 1,

    /// <summary>
    /// Cancel Taker
    /// </summary>
    [Map("CancelTaker")]
    CancelTaker = 2,

    /// <summary>
    /// Cancel Both
    /// </summary>
    [Map("CancelBoth")]
    CancelBoth = 3,
}