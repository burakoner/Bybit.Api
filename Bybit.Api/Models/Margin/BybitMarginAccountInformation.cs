namespace Bybit.Api.Models.Margin;

public class BybitMarginAccountInformation
{
    /// <summary>
    /// Total equity (BTC)
    /// </summary>
    [JsonProperty("acctBalanceSum")]
    public decimal AccountBalanceTotal { get; set; }

    /// <summary>
    /// Total liability (BTC)
    /// </summary>
    [JsonProperty("debtBalanceSum")]
    public decimal DebtBalanceTotal { get; set; }

    /// <summary>
    /// Risk rate
    /// </summary>
    public decimal RiskRate { get; set; }

    [JsonProperty("loanAccountList")]
    public IEnumerable<BybitLoanBalance> LoanBalances { get; set; }
}

public class BybitLoanBalance
{
    [JsonProperty("tokenId")]
    public string Asset { get; set; }
    public decimal Total { get; set; }
    public decimal Free { get; set; }
    public decimal Locked { get; set; }
    public decimal Loan { get; set; }
    public decimal Interest { get; set; }

    /// <summary>
    /// Remaining debt = interest + loan
    /// </summary>
    public decimal RemainAmount { get; set; }
    
}
