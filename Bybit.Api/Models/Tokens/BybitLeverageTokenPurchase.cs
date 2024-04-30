namespace Bybit.Api.Models.Tokens;

/// <summary>
/// Bybit Leveraged Token Purchase
/// </summary>
public class BybitLeverageTokenPurchase
{
    /// <summary>
    /// Abbreviation of the LT, such as BTC3L
    /// </summary>
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order status. 1: completed, 2: in progress, 3: failed
    /// </summary>
    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLeverageTokenOrderStatus>))]
    public BybitLeverageTokenOrderStatus Status { get; set; }

    /// <summary>
    /// Purchase amount
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Executed amount of LT
    /// </summary>
    [JsonProperty("execAmt")]
    public decimal? ExecutedAmount { get; set; }

    /// <summary>
    /// Executed qty of LT
    /// </summary>
    [JsonProperty("execQty")]
    public decimal? ExecutedQuantity { get; set; }

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("purchaseId")]
    public string PurchaseId { get; set; }

    /// <summary>
    /// Serial number, customised order ID
    /// </summary>
    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Quote coin
    /// </summary>
    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }
}