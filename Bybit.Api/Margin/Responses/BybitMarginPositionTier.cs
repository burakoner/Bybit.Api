namespace Bybit.Api.Margin;

/// <summary>
/// Spot margin position tiers for a coin.
/// </summary>
public record BybitMarginPositionTier
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Position tier ratios.
    /// </summary>
    public List<BybitMarginPositionTierRatio> PositionTiersRatioList { get; set; } = [];
}

/// <summary>
/// Spot margin position tier ratio.
/// </summary>
public record BybitMarginPositionTierRatio
{
    /// <summary>
    /// Tier number.
    /// </summary>
    public int Tier { get; set; }

    /// <summary>
    /// Tiers accumulation borrow limit.
    /// </summary>
    public decimal BorrowLimit { get; set; }

    /// <summary>
    /// Loan maintenance margin rate.
    /// </summary>
    [JsonProperty("positionMMR")]
    public decimal PositionMaintenanceMarginRate { get; set; }

    /// <summary>
    /// Loan initial margin rate.
    /// </summary>
    [JsonProperty("positionIMR")]
    public decimal PositionInitialMarginRate { get; set; }

    /// <summary>
    /// Max loan leverage.
    /// </summary>
    public decimal MaxLeverage { get; set; }
}
