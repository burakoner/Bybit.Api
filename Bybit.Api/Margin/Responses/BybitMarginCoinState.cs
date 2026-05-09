namespace Bybit.Api.Margin;

/// <summary>
/// Spot margin coin state.
/// </summary>
public record BybitMarginCoinState
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Spot margin leverage. Null if spot margin mode is turned off.
    /// </summary>
    public decimal? SpotLeverage { get; set; }
}
