namespace Bybit.Api.Enums;

/// <summary>
/// Fixed-rate borrow strategy type.
/// </summary>
public enum BybitFixedBorrowStrategyType
{
    /// <summary>
    /// Allow partial fill.
    /// </summary>
    [Map("PARTIAL")]
    Partial = 1,

    /// <summary>
    /// Full fill only.
    /// </summary>
    [Map("FULL")]
    Full = 2,
}
