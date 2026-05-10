namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan collateral request item.
/// </summary>
public record BybitCryptoLoanCollateralRequestItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanCollateralRequestItem"/> record.
    /// </summary>
    /// <param name="currency">Collateral coin.</param>
    /// <param name="amount">Collateral amount.</param>
    public BybitCryptoLoanCollateralRequestItem(string currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    /// <summary>
    /// Collateral coin.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Collateral amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }
}
