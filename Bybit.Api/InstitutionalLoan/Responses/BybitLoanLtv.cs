namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Institutional loan-to-value information.
/// </summary>
public record BybitLoanLtv
{
    /// <summary>
    /// Loan-to-value information.
    /// </summary>
    public List<BybitLoanLtvInfo> LtvInfo { get; set; } = [];

    /// <summary>
    /// Liquidation status.
    /// </summary>
    [JsonProperty("liqStatus")]
    public BybitLoanLiquidationStatus? LiquidationStatus { get; set; }
}

/// <summary>
/// Institutional loan-to-value risk unit information.
/// </summary>
public record BybitLoanLtvInfo
{
    /// <summary>
    /// Risk rate.
    /// </summary>
    public decimal? Ltv { get; set; }

    /// <summary>
    /// Remaining liquidation time in seconds. Empty when not triggered.
    /// </summary>
    [JsonProperty("rst")]
    public long? RemainingLiquidationTime { get; set; }

    /// <summary>
    /// Designated risk unit UID.
    /// </summary>
    public string ParentUid { get; set; } = string.Empty;

    /// <summary>
    /// Bound user IDs.
    /// </summary>
    public List<string> SubAccountUids { get; set; } = [];

    /// <summary>
    /// Total debt in USDT.
    /// </summary>
    public decimal? UnpaidAmount { get; set; }

    /// <summary>
    /// Debt details.
    /// </summary>
    public List<BybitLoanLtvUnpaidInfo> UnpaidInfo { get; set; } = [];

    /// <summary>
    /// Total asset value after margin coin conversion to USDT.
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// Asset details.
    /// </summary>
    public List<BybitLoanLtvBalanceInfo> BalanceInfo { get; set; } = [];

    /// <summary>
    /// Liquidation status.
    /// </summary>
    [JsonProperty("liqStatus")]
    public BybitLoanLiquidationStatus? LiquidationStatus { get; set; }
}

/// <summary>
/// Institutional loan debt detail.
/// </summary>
public record BybitLoanLtvUnpaidInfo
{
    /// <summary>
    /// Coin.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Unpaid principal.
    /// </summary>
    public decimal UnpaidQty { get; set; }

    /// <summary>
    /// Unpaid interest.
    /// </summary>
    public decimal UnpaidInterest { get; set; }
}

/// <summary>
/// Institutional loan asset detail.
/// </summary>
public record BybitLoanLtvBalanceInfo
{
    /// <summary>
    /// Margin coin.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Margin coin price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Margin coin quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Margin conversion amount.
    /// </summary>
    public decimal ConvertedAmount { get; set; }
}
