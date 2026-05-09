namespace Bybit.Api.Margin;

internal record BybitMarginAutoRepayModeContainer
{
    /// <summary>
    /// Auto-repay mode data.
    /// </summary>
    public List<BybitMarginAutoRepayMode> Data { get; set; } = [];
}

/// <summary>
/// Spot automatic repayment mode.
/// </summary>
public record BybitMarginAutoRepayMode
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Auto repay mode.
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool AutoRepayMode { get; set; }
}
