namespace Bybit.Api.Models.LToken;

public class BybitLeveragedTokenPurchase
{
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLtOrderStatus>))]
    public BybitLtOrderStatus Status { get; set; }

    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonProperty("execAmt")]
    public decimal? ExecutedAmount { get; set; }

    [JsonProperty("execQty")]
    public decimal? ExecutedQuantity { get; set; }

    [JsonProperty("purchaseId")]
    public string PurchaseId { get; set; }

    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }

    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }
}