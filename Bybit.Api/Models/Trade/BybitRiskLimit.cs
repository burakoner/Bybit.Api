namespace Bybit.Api.Models.Trade;

/// <summary>
/// Bybit Risk Limit
/// </summary>
public class BybitRiskLimit
{
    /// <summary>
    /// Category
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
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
