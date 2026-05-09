namespace Bybit.Api.Margin;

/// <summary>
/// Spot margin status and leverage.
/// </summary>
public record BybitMarginStatus
{
    /// <summary>
    /// Spot margin leverage. Null if margin trade is turned off.
    /// </summary>
    public decimal? SpotLeverage { get; set; }

    /// <summary>
    /// Spot margin status.
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool SpotMarginMode { get; set; }

    /// <summary>
    /// Actual leverage ratio.
    /// </summary>
    public decimal? EffectiveLeverage { get; set; }
}
