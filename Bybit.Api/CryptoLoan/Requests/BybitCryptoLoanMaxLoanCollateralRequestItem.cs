namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Collateral item for maximum crypto loan calculation.
/// </summary>
public record BybitCryptoLoanMaxLoanCollateralRequestItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanMaxLoanCollateralRequestItem"/> record.
    /// </summary>
    /// <param name="currency">Collateral coin.</param>
    /// <param name="amount">Collateral amount.</param>
    public BybitCryptoLoanMaxLoanCollateralRequestItem(string currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    /// <summary>
    /// Collateral coin.
    /// </summary>
    [JsonProperty("ccy")]
    public string Currency { get; set; }

    /// <summary>
    /// Collateral amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }
}
