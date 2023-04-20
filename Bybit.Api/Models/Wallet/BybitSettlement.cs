namespace Bybit.Api.Models.Wallet;

public class BybitSettlement
{
    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }
    
    [JsonProperty("size")]
    public decimal Quantity { get; set; }
    
    [JsonProperty("sessionAvgPrice")]
    public decimal SettlementPrice { get; set; }
    
    public decimal MarkPrice { get; set; }
    
    [JsonProperty("realisedPnl")]
    public decimal RealizedPnl { get; set; }
    
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }
}
