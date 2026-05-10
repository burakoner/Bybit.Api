namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan position.
/// </summary>
public record BybitCryptoLoanPosition
{
    /// <summary>
    /// Borrow positions.
    /// </summary>
    public List<BybitCryptoLoanBorrowPosition> BorrowList { get; set; } = [];

    /// <summary>
    /// Collateral positions.
    /// </summary>
    public List<BybitCryptoLoanCollateralPosition> CollateralList { get; set; } = [];

    /// <summary>
    /// Loan-to-value ratio.
    /// </summary>
    [JsonProperty("ltv")]
    public decimal Ltv { get; set; }

    /// <summary>
    /// Supply positions.
    /// </summary>
    public List<BybitCryptoLoanSupplyPosition> SupplyList { get; set; } = [];

    /// <summary>
    /// Total collateral amount in USD.
    /// </summary>
    public decimal TotalCollateral { get; set; }

    /// <summary>
    /// Total debt amount in USD.
    /// </summary>
    public decimal TotalDebt { get; set; }

    /// <summary>
    /// Total supply amount in USD.
    /// </summary>
    public decimal TotalSupply { get; set; }
}

/// <summary>
/// Crypto loan borrow position.
/// </summary>
public record BybitCryptoLoanBorrowPosition
{
    /// <summary>
    /// Total fixed loan debt in coin.
    /// </summary>
    public decimal FixedTotalDebt { get; set; }

    /// <summary>
    /// Total fixed loan debt in USD.
    /// </summary>
    [JsonProperty("fixedTotalDebtUSD")]
    public decimal FixedTotalDebtUsd { get; set; }

    /// <summary>
    /// Flexible loan hourly interest rate.
    /// </summary>
    public decimal FlexibleHourlyInterestRate { get; set; }

    /// <summary>
    /// Total flexible loan debt in coin.
    /// </summary>
    public decimal FlexibleTotalDebt { get; set; }

    /// <summary>
    /// Total flexible loan debt in USD.
    /// </summary>
    [JsonProperty("flexibleTotalDebtUSD")]
    public decimal FlexibleTotalDebtUsd { get; set; }

    /// <summary>
    /// Loan coin.
    /// </summary>
    public string LoanCurrency { get; set; } = string.Empty;
}

/// <summary>
/// Crypto loan collateral position.
/// </summary>
public record BybitCryptoLoanCollateralPosition
{
    /// <summary>
    /// Collateral amount in coin.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Collateral amount in USD.
    /// </summary>
    [JsonProperty("amountUSD")]
    public decimal AmountUsd { get; set; }

    /// <summary>
    /// Collateral coin.
    /// </summary>
    public string Currency { get; set; } = string.Empty;
}

/// <summary>
/// Crypto loan supply position.
/// </summary>
public record BybitCryptoLoanSupplyPosition
{
    /// <summary>
    /// Supply amount in coin.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Supply amount in USD.
    /// </summary>
    [JsonProperty("amountUSD")]
    public decimal AmountUsd { get; set; }

    /// <summary>
    /// Supply coin.
    /// </summary>
    public string Currency { get; set; } = string.Empty;
}
