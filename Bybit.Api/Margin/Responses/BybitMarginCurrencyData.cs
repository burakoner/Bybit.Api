namespace Bybit.Api.Margin;

/// <summary>
/// Spot margin currency data.
/// </summary>
public record BybitMarginCurrencyData
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Whether flexible manual borrow is enabled.
    /// </summary>
    public bool FlexibleManualBorrowable { get; set; }

    /// <summary>
    /// Min flexible manual borrow qty.
    /// </summary>
    public decimal? MinFlexibleManualBorrowQty { get; set; }

    /// <summary>
    /// Coin precision for flexible manual borrow.
    /// </summary>
    public int? FlexibleManualBorrowAccuracy { get; set; }

    /// <summary>
    /// Whether fixed manual borrow is enabled.
    /// </summary>
    public bool FixedManualBorrowable { get; set; }

    /// <summary>
    /// Min fixed manual borrow qty.
    /// </summary>
    public decimal? MinFixedManualBorrowQty { get; set; }

    /// <summary>
    /// Coin precision for fixed manual borrow.
    /// </summary>
    public int? FixedManualBorrowAccuracy { get; set; }

    /// <summary>
    /// Precision for fixed manual borrow interest rate.
    /// </summary>
    public int? FixedInterestRateAccuracy { get; set; }

    /// <summary>
    /// Min fixed manual borrow interest rate.
    /// </summary>
    public decimal? MinFixedInterestRate { get; set; }

    /// <summary>
    /// Max fixed manual borrow interest rate.
    /// </summary>
    public decimal? MaxFixedInterestRate { get; set; }
}
