namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Flexible crypto loan borrow request.
/// </summary>
public record BybitCryptoLoanFlexibleBorrowRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFlexibleBorrowRequest"/> record.
    /// </summary>
    /// <param name="loanCurrency">Loan coin.</param>
    /// <param name="loanAmount">Amount to borrow.</param>
    public BybitCryptoLoanFlexibleBorrowRequest(string loanCurrency, decimal loanAmount)
    {
        LoanCurrency = loanCurrency;
        LoanAmount = loanAmount;
    }

    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency")]
    public string LoanCurrency { get; set; }

    /// <summary>
    /// Amount to borrow.
    /// </summary>
    [JsonProperty("loanAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal LoanAmount { get; set; }

    /// <summary>
    /// Collateral coin list.
    /// </summary>
    [JsonProperty("collateralList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitCryptoLoanCollateralRequestItem>? CollateralList { get; set; }
}
