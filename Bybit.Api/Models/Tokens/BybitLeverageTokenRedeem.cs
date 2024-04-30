namespace Bybit.Api.Models.Tokens;

/// <summary>
/// Bybit Leveraged Token Redeem
/// </summary>
public class BybitLeverageTokenRedeem
{
    /// <summary>
    /// Abbreviation of the LT
    /// </summary>
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order status. 1: completed, 2: in progress, 3: failed
    /// </summary>
    [JsonProperty("ltOrderStatus"), JsonConverter(typeof(LabelConverter<BybitLeverageTokenOrderStatus>))]
    public BybitLeverageTokenOrderStatus Status { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("quantity")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// LT quantity
    /// </summary>
    [JsonProperty("execQty")]
    public decimal? ExecutedQuantity { get; set; }

    /// <summary>
    /// Executed amount of LT
    /// </summary>
    [JsonProperty("execAmt")]
    public decimal? ExecutedAmount { get; set; }

    /// <summary>
    /// Order ID
    /// </summary>
    [JsonProperty("redeemId")]
    public string RedeemId { get; set; }

    /// <summary>
    /// Serial number
    /// </summary>
    [JsonProperty("serialNo")]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Quote coin
    /// </summary>
    [JsonProperty("valueCoin")]
    public string ValueCoin { get; set; }
}