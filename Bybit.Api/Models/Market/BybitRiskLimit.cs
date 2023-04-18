namespace Bybit.Api.Models.Market;

public class BybitRiskLimit
{
    public long Id { get; set; }
    public string Symbol { get; set; }
    public decimal RiskLimitValue { get; set; }
    public decimal MaintenanceMargin { get; set; }
    public decimal InitialMargin { get; set; }
    public bool IsLowestRisk { get; set; }
    public decimal MaxLeverage { get; set; }
}