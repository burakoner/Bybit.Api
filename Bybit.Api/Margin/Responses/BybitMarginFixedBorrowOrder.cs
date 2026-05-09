namespace Bybit.Api.Margin;

/// <summary>
/// Fixed-rate borrow order information.
/// </summary>
public record BybitMarginFixedBorrowOrder
{
    /// <summary>
    /// Annual rate for the borrowing.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Loan order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Order created timestamp.
    /// </summary>
    public long OrderTime { get; set; }

    /// <summary>
    /// Order created time.
    /// </summary>
    public DateTime CreatedTime { get => OrderTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// Filled quantity.
    /// </summary>
    public decimal FilledQty { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    public decimal OrderQty { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string OrderCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Borrow order state.
    /// </summary>
    public BybitFixedBorrowOrderState State { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitFixedBorrowRepayType RepayType { get; set; }

    /// <summary>
    /// Strategy type.
    /// </summary>
    public BybitFixedBorrowStrategyType StrategyType { get; set; }
}
