namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Create fixed crypto loan supply order request.
/// </summary>
public record BybitCryptoLoanFixedSupplyRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFixedSupplyRequest"/> record.
    /// </summary>
    /// <param name="orderCurrency">Currency to supply.</param>
    /// <param name="orderAmount">Amount to supply.</param>
    /// <param name="annualRate">Annual interest rate.</param>
    /// <param name="term">Fixed term in days.</param>
    public BybitCryptoLoanFixedSupplyRequest(string orderCurrency, decimal orderAmount, decimal annualRate, int term)
    {
        OrderCurrency = orderCurrency;
        OrderAmount = orderAmount;
        AnnualRate = annualRate;
        Term = term;
    }

    /// <summary>
    /// Currency to supply.
    /// </summary>
    [JsonProperty("orderCurrency")]
    public string OrderCurrency { get; set; }

    /// <summary>
    /// Amount to supply.
    /// </summary>
    [JsonProperty("orderAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal OrderAmount { get; set; }

    /// <summary>
    /// Annual interest rate.
    /// </summary>
    [JsonProperty("annualRate"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal AnnualRate { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    [JsonProperty("term"), JsonConverter(typeof(IntegerToStringConverter))]
    public int Term { get; set; }

    /// <summary>
    /// Source account for supply.
    /// </summary>
    [JsonProperty("availableSource", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCryptoLoanSupplyAvailableSource? AvailableSource { get; set; }
}
