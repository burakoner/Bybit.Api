namespace Bybit.Api.Models.Wallet;

public class BybitAssetExchange
{
    [JsonProperty("fromCoin")]
    public string FromAsset { get; set; }

    [JsonProperty("fromAmount")]
    public decimal FromQuantity { get; set; }

    [JsonProperty("toCoin")]
    public string ToAsset { get; set; }
    
    [JsonProperty("toAmount")]
    public decimal ToQuantity { get; set; }
    
    public decimal ExchangeRate { get; set; }
    
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }
    
    [JsonProperty("exchangeTxId")]
    public string TransactionId { get; set; }
}
