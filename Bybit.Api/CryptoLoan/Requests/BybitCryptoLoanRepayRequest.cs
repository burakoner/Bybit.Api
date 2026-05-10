namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan repayment request.
/// </summary>
public record BybitCryptoLoanRepayRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanRepayRequest"/> record.
    /// </summary>
    /// <param name="loanCurrency">Loan coin.</param>
    /// <param name="amount">Repayment amount.</param>
    public BybitCryptoLoanRepayRequest(string loanCurrency, decimal amount)
    {
        LoanCurrency = loanCurrency;
        Amount = amount;
    }

    /// <summary>
    /// Loan coin.
    /// </summary>
    [JsonProperty("loanCurrency")]
    public string LoanCurrency { get; set; }

    /// <summary>
    /// Repayment amount.
    /// </summary>
    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Amount { get; set; }
}
