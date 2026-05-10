namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Create fixed crypto loan borrow order request.
/// </summary>
public record BybitCryptoLoanFixedBorrowRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFixedBorrowRequest"/> record.
    /// </summary>
    /// <param name="orderCurrency">Currency to borrow.</param>
    /// <param name="orderAmount">Amount to borrow.</param>
    /// <param name="annualRate">Annual interest rate.</param>
    /// <param name="term">Fixed term in days.</param>
    public BybitCryptoLoanFixedBorrowRequest(string orderCurrency, decimal orderAmount, decimal annualRate, int term)
    {
        OrderCurrency = orderCurrency;
        OrderAmount = orderAmount;
        AnnualRate = annualRate;
        Term = term;
    }

    /// <summary>
    /// Currency to borrow.
    /// </summary>
    [JsonProperty("orderCurrency")]
    public string OrderCurrency { get; set; }

    /// <summary>
    /// Amount to borrow.
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
    /// Deprecated auto-repay setting.
    /// </summary>
    [JsonIgnore]
    public bool? AutoRepay { get; set; }

    [JsonProperty("autoRepay", NullValueHandling = NullValueHandling.Ignore)]
    private string? AutoRepayValue { get => AutoRepay == null ? null : AutoRepay.Value ? "true" : "false"; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    [JsonProperty("repayType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitFixedBorrowRepayType? RepayType { get; set; }

    /// <summary>
    /// Collateral coin list.
    /// </summary>
    [JsonProperty("collateralList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitCryptoLoanCollateralRequestItem>? CollateralList { get; set; }
}
