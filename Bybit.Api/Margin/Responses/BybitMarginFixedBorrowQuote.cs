namespace Bybit.Api.Margin;

/// <summary>
/// Fixed-rate borrow order quote.
/// </summary>
public record BybitMarginFixedBorrowQuote
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string OrderCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int Term { get; set; }

    /// <summary>
    /// Annual rate.
    /// </summary>
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }
}
