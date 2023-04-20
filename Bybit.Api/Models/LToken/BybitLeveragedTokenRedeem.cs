namespace Bybit.Api.Models.LToken;

public class BybitLeveragedTokenRedeem
{
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLtOrderStatus>))]
    public BybitLtOrderStatus Status { get; set; }

    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }

    [JsonProperty("execQty")]
    public decimal? ExecutedQuantity { get; set; }

    [JsonProperty("execAmt")]
    public decimal? ExecutedAmount { get; set; }

    [JsonProperty("redeemId")]
    public string RedeemId { get; set; }

    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }

    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }
}