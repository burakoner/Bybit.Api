namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Execution Type
/// </summary>
public enum BybitExecutionType
{
    /// <summary>
    /// Trade
    /// </summary>
    [Label("Trade")]
    Trade,

    /// <summary>
    /// Auto Deleveraging
    /// </summary>
    [Label("AdlTrade")]
    AutoDeleveraging,

    /// <summary>
    /// Funding
    /// </summary>
    [Label("Funding")]
    Funding,

    /// <summary>
    /// Bust Trade
    /// </summary>
    [Label("BustTrade")]
    BustTrade,

    /// <summary>
    /// Delivery
    /// </summary>
    [Label("Delivery")]
    Delivery,

    /// <summary>
    /// Settle
    /// </summary>
    [Label("Settle")]
    Settle,

    /// <summary>
    /// Block Trade
    /// </summary>
    [Label("BlockTrade")]
    BlockTrade,

    /// <summary>
    /// Move Position
    /// </summary>
    [Label("MovePosition")]
    MovePosition,

    /// <summary>
    /// Unknown
    /// </summary>
    [Label("UNKNOWN")]
    Unknown,
}