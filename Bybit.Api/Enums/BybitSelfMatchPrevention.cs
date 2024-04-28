namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Self Match Prevention
/// </summary>
public enum BybitSelfMatchPrevention
{
    /// <summary>
    /// None
    /// </summary>
    [Label("None")]
    None,

    /// <summary>
    /// Cancel Maker
    /// </summary>
    [Label("CancelMaker")]
    CancelMaker,

    /// <summary>
    /// Cancel Taker
    /// </summary>
    [Label("CancelTaker")]
    CancelTaker,

    /// <summary>
    /// Cancel Both
    /// </summary>
    [Label("CancelBoth")]
    CancelBoth,
}