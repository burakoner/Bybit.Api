namespace Bybit.Api.Margin;

/// <summary>
/// Tiered collateral ratio data.
/// </summary>
public record BybitMarginTieredCollateralRatio
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Collateral ratio tiers.
    /// </summary>
    public List<BybitMarginCollateralRatioTier> CollateralRatioList { get; set; } = [];
}

/// <summary>
/// Collateral ratio tier.
/// </summary>
public record BybitMarginCollateralRatioTier
{
    /// <summary>
    /// Lower limit of the tier range.
    /// </summary>
    public decimal MinQty { get; set; }

    /// <summary>
    /// Upper limit of the tier range. Null means positive infinity.
    /// </summary>
    public decimal? MaxQty { get; set; }

    /// <summary>
    /// Collateral ratio.
    /// </summary>
    public decimal CollateralRatio { get; set; }
}
