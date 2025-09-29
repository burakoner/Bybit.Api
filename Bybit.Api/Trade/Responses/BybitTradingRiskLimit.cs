namespace Bybit.Api.Trade;

/// <summary>
/// Bybit Risk Limit
/// </summary>
public record BybitTradingRiskLimit
{
    /// <summary>
    /// Category
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Risk Id
    /// </summary>
    public long RiskId { get; set; }

    /// <summary>
    /// Risk Limit Value
    /// </summary>
    public decimal RiskLimitValue { get; set; }
}
