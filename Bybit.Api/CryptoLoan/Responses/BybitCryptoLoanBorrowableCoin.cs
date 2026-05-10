namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan borrowable coin data.
/// </summary>
public record BybitCryptoLoanBorrowableCoin
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Whether fixed loan is supported.
    /// </summary>
    public bool FixedBorrowable { get; set; }

    /// <summary>
    /// Coin precision for fixed loan.
    /// </summary>
    public int? FixedBorrowingAccuracy { get; set; }

    /// <summary>
    /// Whether flexible loan is supported.
    /// </summary>
    public bool FlexibleBorrowable { get; set; }

    /// <summary>
    /// Coin precision for flexible loan.
    /// </summary>
    public int? FlexibleBorrowingAccuracy { get; set; }

    /// <summary>
    /// Maximum borrow limit.
    /// </summary>
    public decimal MaxBorrowingAmount { get; set; }

    /// <summary>
    /// Minimum amount for each fixed loan order.
    /// </summary>
    public decimal? MinFixedBorrowingAmount { get; set; }

    /// <summary>
    /// Minimum amount for each flexible loan order.
    /// </summary>
    public decimal? MinFlexibleBorrowingAmount { get; set; }

    /// <summary>
    /// VIP level.
    /// </summary>
    public string VipLevel { get; set; } = string.Empty;

    /// <summary>
    /// Flexible annualized interest rate.
    /// </summary>
    public decimal? FlexibleAnnualizedInterestRate { get; set; }

    /// <summary>
    /// Lowest 7 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate7D")]
    public decimal? AnnualizedInterestRate7D { get; set; }

    /// <summary>
    /// Lowest 14 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate14D")]
    public decimal? AnnualizedInterestRate14D { get; set; }

    /// <summary>
    /// Lowest 30 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate30D")]
    public decimal? AnnualizedInterestRate30D { get; set; }

    /// <summary>
    /// Lowest 60 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate60D")]
    public decimal? AnnualizedInterestRate60D { get; set; }

    /// <summary>
    /// Lowest 90 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate90D")]
    public decimal? AnnualizedInterestRate90D { get; set; }

    /// <summary>
    /// Lowest 180 day fixed annualized interest rate.
    /// </summary>
    [JsonProperty("annualizedInterestRate180D")]
    public decimal? AnnualizedInterestRate180D { get; set; }
}
