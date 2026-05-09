namespace Bybit.Api.Margin;

/// <summary>
/// Get fixed-rate borrow order info request.
/// </summary>
public record BybitMarginFixedBorrowOrderInfoRequest
{
    /// <summary>
    /// Loan order ID.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// Loan coin name.
    /// </summary>
    public string? OrderCurrency { get; set; }

    /// <summary>
    /// Borrow order state.
    /// </summary>
    public BybitFixedBorrowOrderState? State { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int? Term { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    public string? Cursor { get; set; }
}
