namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Obtain maximum crypto loan amount request.
/// </summary>
public record BybitCryptoLoanMaxLoanAmountRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanMaxLoanAmountRequest"/> record.
    /// </summary>
    /// <param name="currency">Coin to borrow.</param>
    public BybitCryptoLoanMaxLoanAmountRequest(string currency)
    {
        Currency = currency;
    }

    /// <summary>
    /// Coin to borrow.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Optional collateral list.
    /// </summary>
    [JsonProperty("collateralList", NullValueHandling = NullValueHandling.Ignore)]
    public List<BybitCryptoLoanMaxLoanCollateralRequestItem>? CollateralList { get; set; }
}
