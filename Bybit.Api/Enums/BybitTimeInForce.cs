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

    /// <summary>
    /// Exclusive Matching: Only match non-algorithmic users; no execution against orders from Open API.
    /// Post-Only Mechanism: Act as maker orders, adding liquidity
    /// Lower Priority: Execute after non-RPI orders at the same price level.
    /// Limited Access: Initially for select market makers across multiple pairs.
    /// Order Book Updates: Excluded from API but displayed on the GUI.
    /// </summary>
    [Map("RPI")]
    RPI = 5,
}