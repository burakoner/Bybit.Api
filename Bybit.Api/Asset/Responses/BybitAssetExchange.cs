namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Asset Record
/// </summary>
public class BybitAssetExchange
{
    /// <summary>
    /// From Asset
    /// </summary>
    [JsonProperty("fromCoin")]
    public string FromAsset { get; set; }

    /// <summary>
    /// From Quantity
    /// </summary>
    [JsonProperty("fromAmount")]
    public decimal FromQuantity { get; set; }

    /// <summary>
    /// To Asset
    /// </summary>
    [JsonProperty("toCoin")]
    public string ToAsset { get; set; }

    /// <summary>
    /// To Quantity
    /// </summary>
    [JsonProperty("toAmount")]
    public decimal ToQuantity { get; set; }

    /// <summary>
    /// Exchange Rate
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Exchange created timestamp (sec)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Exchange created timestamp
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Exchange transaction ID
    /// </summary>
    [JsonProperty("exchangeTxId")]
    public string TransactionId { get; set; }
}
