namespace Bybit.Api.Models.Trading;

public class BybitTakeProfitStopLoss
{
    [JsonProperty("tpSlMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode TakeProfitStopLossMode { get; set; }
}
