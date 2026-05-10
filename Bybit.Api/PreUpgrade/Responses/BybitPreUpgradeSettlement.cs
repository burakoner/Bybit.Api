namespace Bybit.Api.PreUpgrade;

/// <summary>
/// Pre-upgrade USDC session settlement item.
/// </summary>
public record BybitPreUpgradeSettlement
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Side.
    /// </summary>
    public BybitOrderSide? Side { get; set; }

    /// <summary>
    /// Position size.
    /// </summary>
    [JsonProperty("size")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Settlement price.
    /// </summary>
    [JsonProperty("sessionAvgPrice")]
    public decimal? SettlementPrice { get; set; }

    /// <summary>
    /// Mark price.
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Realised PnL.
    /// </summary>
    [JsonProperty("realisedPnl")]
    public decimal? RealisedPnl { get; set; }

    /// <summary>
    /// Created timestamp in milliseconds.
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Created time.
    /// </summary>
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }
}
