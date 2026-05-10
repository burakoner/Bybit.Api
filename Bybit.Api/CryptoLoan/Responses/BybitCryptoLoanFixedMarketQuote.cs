namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Fixed crypto loan market quote.
/// </summary>
public record BybitCryptoLoanFixedMarketQuote
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
