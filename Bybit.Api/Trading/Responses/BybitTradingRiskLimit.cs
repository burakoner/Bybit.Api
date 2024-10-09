namespace Bybit.Api.Trading;

/// <summary>
/// Bybit Risk Limit
/// </summary>
public class BybitTradingRiskLimit
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
