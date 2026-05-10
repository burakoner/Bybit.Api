namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan collateral adjustment history item.
/// </summary>
public record BybitCryptoLoanCollateralAdjustment
{
    /// <summary>
    /// Collateral adjustment transaction ID.
    /// </summary>
    public long AdjustId { get; set; }

    /// <summary>
    /// Adjustment timestamp.
    /// </summary>
    public long AdjustTime { get; set; }

    /// <summary>
    /// Adjustment time.
    /// </summary>
    public DateTime AdjustmentTime { get => AdjustTime.ConvertFromMilliseconds(); }

    /// <summary>
    /// LTV after the adjustment.
    /// </summary>
    [JsonProperty("afterLTV")]
    public decimal AfterLtv { get; set; }

    /// <summary>
    /// Adjustment amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Collateral coin.
    /// </summary>
    public string CollateralCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Adjustment direction.
    /// </summary>
    public BybitCryptoLoanAdjustmentDirection Direction { get; set; }

    /// <summary>
    /// LTV before the adjustment.
    /// </summary>
    [JsonProperty("preLTV")]
    public decimal PreLtv { get; set; }

    /// <summary>
    /// Adjustment status.
    /// </summary>
    public BybitCryptoLoanOperationStatus Status { get; set; }
}
