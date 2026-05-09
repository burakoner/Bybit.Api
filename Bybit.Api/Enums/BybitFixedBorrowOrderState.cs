namespace Bybit.Api.Enums;

/// <summary>
/// Fixed-rate borrow order state.
/// </summary>
public enum BybitFixedBorrowOrderState
{
    /// <summary>
    /// Matching.
    /// </summary>
    [Map("1")]
    Matching = 1,

    /// <summary>
    /// Partially filled and cancelled.
    /// </summary>
    [Map("2")]
    PartiallyFilledAndCancelled = 2,

    /// <summary>
    /// Fully filled.
    /// </summary>
    [Map("3")]
    FullyFilled = 3,

    /// <summary>
    /// Cancelled.
    /// </summary>
    [Map("4")]
    Cancelled = 4,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("5")]
    Failed = 5,
}
