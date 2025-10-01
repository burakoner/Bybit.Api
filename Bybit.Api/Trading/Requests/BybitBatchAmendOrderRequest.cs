namespace Bybit.Api.Trading;

/// <summary>
/// Batch amend order request
/// </summary>
public record BybitBatchAmendOrderRequest
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID. Either orderId or orderLinkId is required
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed.
    /// </summary>
    [JsonProperty("orderIv", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? ImpliedVolatility { get; set; }

    /// <summary>
    /// Trigger price
    /// </summary>
    [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Order quantity after modification. Do not pass it if not modify the qty
    /// </summary>
    [JsonProperty("qty", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Order price after modification. Do not pass it if not modify the price
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Price { get; set; }

    /// <summary>
    /// TP/SL mode
    /// Full: entire position for TP/SL. Then, tpOrderType or slOrderType must be Market
    /// Partial: partial position tp/sl (as there is no size option, so it will create tp/sl orders with the qty you actually fill). Limit TP/SL order are supported. Note: When create limit tp/sl, tpslMode is required and it must be Partial
    /// Valid for linear
    /// </summary>
    [JsonProperty("tpslMode", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// 	Take profit price after modification. If pass "0", it means cancel the existing take profit of the order. Do not pass it if you do not want to modify the take profit. valid for spot, linear
    /// </summary>
    [JsonProperty("takeProfit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfit { get; set; }

    /// <summary>
    /// Stop loss price after modification. If pass "0", it means cancel the existing stop loss of the order. Do not pass it if you do not want to modify the stop loss. valid for spot, linear
    /// </summary>
    [JsonProperty("stopLoss", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLoss { get; set; }

    /// <summary>
    /// The price type to trigger take profit. When set a take profit, this param is required if no initial value for the order
    /// </summary>
    [JsonProperty("tpTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TakeProfitTriggerPriceBy { get; set; }

    /// <summary>
    /// The price type to trigger stop loss. When set a take profit, this param is required if no initial value for the order
    /// </summary>
    [JsonProperty("slTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? StopLossTriggerPriceBy { get; set; }

    /// <summary>
    /// Trigger price type
    /// </summary>
    [JsonProperty("triggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TriggerPriceBy { get; set; }

    /// <summary>
    /// Limit order price when take profit is triggered. Only working when original order sets partial limit tp/sl. valid for spot, linear
    /// </summary>
    [JsonProperty("tpLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// Limit order price when stop loss is triggered. Only working when original order sets partial limit tp/sl. valid for spot, linear
    /// </summary>
    [JsonProperty("slLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLossLimitPrice { get; set; }
}
