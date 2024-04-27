namespace Bybit.Api.Models.Trade;

public class BybitTakeProfitStopLoss
{
    [JsonProperty("tpSlMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode TakeProfitStopLossMode { get; set; }
}
