namespace Bybit.Api.Enums;

/// <summary>
/// Fixed-rate borrow contract status.
/// </summary>
public enum BybitFixedBorrowContractStatus
{
    /// <summary>
    /// Unrepaid.
    /// </summary>
    [Map("1")]
    Unrepaid = 1,

    /// <summary>
    /// Fully repaid.
    /// </summary>
    [Map("2")]
    FullyRepaid = 2,

    /// <summary>
    /// Overdue.
    /// </summary>
    [Map("3")]
    Overdue = 3,
}
