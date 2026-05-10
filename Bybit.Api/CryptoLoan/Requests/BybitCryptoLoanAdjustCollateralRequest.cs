namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Adjust crypto loan collateral amount request.
/// </summary>
public record BybitCryptoLoanAdjustCollateralRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanAdjustCollateralRequest"/> record.
    /// </summary>
    /// <param name="currency">Collateral coin.</param>
    /// <param name="amount">Adjustment amount.</param>
    /// <param name="direction">Adjustment direction.</param>
    public BybitCryptoLoanAdjustCollateralRequest(string currency, decimal amount, BybitCryptoLoanAdjustmentDirection direction)
    {
        Currency = currency;
        Amount = amount;
        Direction = direction;
    }

    /// <summary>
    /// Collateral coin.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Adjustment amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }

    /// <summary>
    /// Adjustment direction.
    /// </summary>
    [JsonProperty("direction")]
    public BybitCryptoLoanAdjustmentDirection Direction { get; set; }
}
