namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Time In Force
/// </summary>
public enum BybitTimeInForce
{
    /// <summary>
    /// Good Till Cancel: Good till canceled by user
    /// </summary>
    [Label("GTC")]
    GoodTillCancel,

    /// <summary>
    /// Immediate Or Cancel: Fill at least partially upon placing or cancel
    /// </summary>
    [Label("IOC")]
    ImmediateOrCancel,

    /// <summary>
    /// Fill Or Kill: Fill fully upon placing or cancel
    /// </summary>
    [Label("FOK")]
    FillOrKill,

    /// <summary>
    /// Post Only: Only place order if the order is added to the order book instead of being filled immediately
    /// </summary>
    [Label("PostOnly")]
    PostOnly,
}