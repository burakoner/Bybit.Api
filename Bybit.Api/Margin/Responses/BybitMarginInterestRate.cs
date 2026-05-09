namespace Bybit.Api.Margin;

/// <summary>
/// Historical spot margin interest rate.
/// </summary>
public record BybitMarginInterestRate
{
    /// <summary>
    /// Timestamp in milliseconds.
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// Timestamp.
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Hourly borrowing rate.
    /// </summary>
    public decimal HourlyBorrowRate { get; set; }

    /// <summary>
    /// VIP/Pro level.
    /// </summary>
    public string VipLevel { get; set; } = string.Empty;
}
