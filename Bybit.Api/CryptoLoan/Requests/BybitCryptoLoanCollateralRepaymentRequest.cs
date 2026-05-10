namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan collateral repayment request.
/// </summary>
public record BybitCryptoLoanCollateralRepaymentRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanCollateralRepaymentRequest"/> record.
    /// </summary>
    /// <param name="loanCurrency">Loan coin.</param>
    /// <param name="collateralCoin">Collateral coins separated by comma.</param>
    /// <param name="amount">Repayment amount.</param>
    public BybitCryptoLoanCollateralRepaymentRequest(string loanCurrency, string collateralCoin, decimal amount)
    {
        LoanCurrency = loanCurrency;
        CollateralCoin = collateralCoin;
        Amount = amount;
    }

    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency")]
    public string LoanCurrency { get; set; }

    /// <summary>
    /// Collateral coins separated by comma.
    /// </summary>
    [JsonProperty("collateralCoin")]
    public string CollateralCoin { get; set; }

    /// <summary>
    /// Repayment amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }

    /// <summary>
    /// Loan contract ID. Fixed loan only.
    /// </summary>
    [JsonProperty("loanId", NullValueHandling = NullValueHandling.Ignore)]
    public string? LoanId { get; set; }
}
