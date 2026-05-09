namespace Bybit.Api.Margin;

/// <summary>
/// Fixed-rate borrow request.
/// </summary>
public record BybitMarginFixedBorrowRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarginFixedBorrowRequest"/> record.
    /// </summary>
    /// <param name="orderCurrency">Currency to borrow.</param>
    /// <param name="orderAmount">Amount to borrow.</param>
    /// <param name="annualRate">Annual interest rate.</param>
    /// <param name="term">Fixed term in days.</param>
    public BybitMarginFixedBorrowRequest(string orderCurrency, decimal orderAmount, decimal annualRate, int term)
    {
        OrderCurrency = orderCurrency;
        OrderAmount = orderAmount;
        AnnualRate = annualRate;
        Term = term;
    }

    /// <summary>
    /// Currency to borrow.
    /// </summary>
    public string OrderCurrency { get; set; }

    /// <summary>
    /// Amount to borrow.
    /// </summary>
    public decimal OrderAmount { get; set; }

    /// <summary>
    /// Annual interest rate.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitFixedBorrowRepayType? RepayType { get; set; }
}
