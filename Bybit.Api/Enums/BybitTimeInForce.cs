namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Time In Force
/// </summary>
public enum BybitTimeInForce
{
    /// <summary>
    /// Good Till Cancel: Good till canceled by user
    /// </summary>
    [Map("GTC")]
    GoodTillCancel = 1,

    /// <summary>
    /// Immediate Or Cancel: Fill at least partially upon placing or cancel
    /// </summary>
    [Map("IOC")]
    ImmediateOrCancel = 2,

    /// <summary>
    /// Fill Or Kill: Fill fully upon placing or cancel
    /// </summary>
    [Map("FOK")]
    FillOrKill = 3,

    /// <summary>
    /// Post Only: Only place order if the order is added to the order book instead of being filled immediately
    /// </summary>
    [Map("PostOnly")]
    PostOnly = 4,
}