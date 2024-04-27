namespace Bybit.Api.Models.Trade;

public class BybitRiskLimit
{
    public long RiskId { get; set; }
    public decimal RiskLimitValue { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }
}
