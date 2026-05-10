namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan borrow order.
/// </summary>
public record BybitCryptoLoanFixedBorrowOrder
{
    /// <summary>
    /// Annual rate for the borrowing.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Filled quantity.
    /// </summary>
    public decimal FilledQty { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string OrderCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Loan order ID.
    /// </summary>
    public long OrderId { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    public decimal OrderQty { get; set; }

    /// <summary>
    /// Order created timestamp.
    /// </summary>
    public long OrderTime { get; set; }

    /// <summary>
    /// Order created time.
    /// </summary>
    public DateTime CreatedTime { get => OrderTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitFixedBorrowRepayType RepayType { get; set; }

    /// <summary>
    /// Borrow order state.
    /// </summary>
    public BybitCryptoLoanFixedOrderState State { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }
}
