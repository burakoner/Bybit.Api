namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Execution Type
/// </summary>
public enum BybitExecutionType
{
    /// <summary>
    /// Trade
    /// </summary>
    [Map("Trade")]
    Trade = 1,

    /// <summary>
    /// Auto Deleveraging
    /// </summary>
    [Map("AdlTrade")]
    AutoDeleveraging = 2,

    /// <summary>
    /// Funding
    /// </summary>
    [Map("Funding")]
    Funding = 3,

    /// <summary>
    /// Bust Trade
    /// </summary>
    [Map("BustTrade")]
    BustTrade = 4,

    /// <summary>
    /// Delivery
    /// </summary>
    [Map("Delivery")]
    Delivery = 5,

    /// <summary>
    /// Settle
    /// </summary>
    [Map("Settle")]
    Settle = 6,

    /// <summary>
    /// Block Trade
    /// </summary>
    [Map("BlockTrade")]
    BlockTrade = 7,

    /// <summary>
    /// Move Position
    /// </summary>
    [Map("MovePosition")]
    MovePosition = 8,

    /// <summary>
    /// Unknown
    /// </summary>
    [Map("UNKNOWN")]
    Unknown = 0,
}