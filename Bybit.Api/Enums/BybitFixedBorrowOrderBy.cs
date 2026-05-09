namespace Bybit.Api.Enums;

/// <summary>
/// Fixed-rate borrow quote sort field.
/// </summary>
public enum BybitFixedBorrowOrderBy
{
    /// <summary>
    /// Annual percentage yield.
    /// </summary>
    [Map("apy")]
    AnnualRate = 1,

    /// <summary>
    /// Fixed term.
    /// </summary>
    [Map("term")]
    Term = 2,

    /// <summary>
    /// Quantity.
    /// </summary>
    [Map("quantity")]
    Quantity = 3,
}
