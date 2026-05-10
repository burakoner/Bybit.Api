namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Renew fixed crypto loan borrow order request.
/// </summary>
public record BybitCryptoLoanFixedRenewRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFixedRenewRequest"/> record.
    /// </summary>
    /// <param name="loanId">Loan ID.</param>
    public BybitCryptoLoanFixedRenewRequest(string loanId)
    {
        LoanId = loanId;
    }

    /// <summary>
    /// Loan ID.
    /// </summary>
    [JsonProperty("loanId")]
    public string LoanId { get; set; }

    /// <summary>
    /// Collateral coin list.
    /// </summary>
    [JsonProperty("collateralList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitCryptoLoanCollateralRequestItem>? CollateralList { get; set; }
}
