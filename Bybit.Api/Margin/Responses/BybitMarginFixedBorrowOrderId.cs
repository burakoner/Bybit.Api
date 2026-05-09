namespace Bybit.Api.Margin;

/// <summary>
/// Fixed-rate borrow order ID.
/// </summary>
public record BybitMarginFixedBorrowOrderId
{
    /// <summary>
    /// Loan order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;
}
