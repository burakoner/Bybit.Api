namespace Bybit.Api.Market;

/// <summary>
/// Bybit Risk Limit
/// </summary>
public record BybitMarketRiskLimit
{
    /// <summary>
    /// Risk limit id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Risk limit value
    /// </summary>
    public decimal RiskLimitValue { get; set; }

    /// <summary>
    /// Maintenance margin
    /// </summary>
    public decimal MaintenanceMargin { get; set; }

    /// <summary>
    /// Initial margin
    /// </summary>
    public decimal InitialMargin { get; set; }

    /// <summary>
    /// Is lowest risk
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool IsLowestRisk { get; set; }

    /// <summary>
    /// Max leverage
    /// </summary>
    public decimal MaxLeverage { get; set; }

    /// <summary>
    /// The maintenance margin deduction value when risk limit tier changed
    /// </summary>
    [JsonProperty("mmDeduction")]
    public decimal MaintenanceMarginDeduction { get; set; }
}