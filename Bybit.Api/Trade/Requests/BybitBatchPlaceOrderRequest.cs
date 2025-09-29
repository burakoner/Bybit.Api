namespace Bybit.Api.Trade;

/// <summary>
/// Place Batch Order Request
/// </summary>
public class BybitBatchPlaceOrderRequest
{
    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Whether to borrow. Valid for Unified spot only.
    /// </summary>
    [JsonIgnore]
    public bool? IsLeverage
    {
        get { return IsLeverageField == 1; }
        set
        {
            if (value == null) IsLeverageField = null;
            else IsLeverageField = value.Value ? 1 : 0;
        }
    }

    /// <summary>
    /// Whether to borrow. Valid for Unified spot only.
    /// </summary>
    [JsonProperty("isLeverage", NullValueHandling = NullValueHandling.Ignore)]
    public int? IsLeverageField { get; private set; }

    /// <summary>
    /// Order side
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order type
    /// </summary>
    [JsonProperty("orderType")]
    public BybitOrderType Type { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Market Unit
    /// </summary>
    [JsonProperty("marketUnit", NullValueHandling = NullValueHandling.Ignore)]
    public BybitUnit? MarketUnit { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Price { get; set; }

    /// <summary>
    /// Trigger direction
    /// </summary>
    [JsonProperty("triggerDirection", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerDirection? TriggerDirection { get; set; }

    /// <summary>
    /// If it is not passed, Order by default.
    /// Order
    /// tpslOrder: Spot TP/SL order, the assets are occupied even before the order is triggered
    /// StopOrder: Spot conditional order, the assets will not be occupied until the price of the underlying asset reaches the trigger price, and the required assets will be occupied after the Conditional order is triggered
    /// Valid for spot only
    /// </summary>
    [JsonProperty("orderFilter", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderFilter? OrderFilter { get; set; }

    /// <summary>
    /// Trigger price
    /// </summary>
    [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Conditional order param (Perps &amp; Futures). Trigger price type. LastPrice, IndexPrice, MarkPrice
    /// </summary>
    [JsonProperty("triggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TriggerPriceBy { get; set; }

    /// <summary>
    /// Implied volatility. option only. Pass the real value, e.g for 10%, 0.1 should be passed. orderIv has a higher priority when price is passed as well
    /// </summary>
    [JsonProperty("orderIv", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? ImpliedVolatility { get; set; }

    /// <summary>
    /// Time in force
    /// </summary>
    [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTimeInForce? TimeInForce { get; set; }

    /// <summary>
    /// Used to identify positions in different position modes. Under hedge-mode, this param is required (USDT perps have hedge mode)
    /// 0: one-way mode
    /// 1: hedge-mode Buy side
    /// 2: hedge-mode Sell side
    /// </summary>
    [JsonProperty("positionIdx", NullValueHandling = NullValueHandling.Ignore)]
    public BybitPositionIndex? PositionIndex { get; set; }

    /// <summary>
    /// User customised order ID. A max of 36 characters. Combinations of numbers, letters (upper and lower cases), dashes, and underscores are supported.
    /// 
    /// Futures, Perps &amp; Spot: orderLinkId rules:
    /// - optional param
    /// - always unique
    /// 
    /// option orderLinkId rules:
    /// - required param
    /// - always unique
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string ClientOrderId { get; set; }

    /// <summary>
    /// Take profit price
    /// </summary>
    [JsonProperty("takeProfit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfit { get; set; }

    /// <summary>
    /// Stop loss price
    /// </summary>
    [JsonProperty("stopLoss", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLoss { get; set; }

    /// <summary>
    /// The price type to trigger take profit. MarkPrice, IndexPrice, default: LastPrice.
    /// Valid for linear
    /// </summary>
    [JsonProperty("tpTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TakeProfitTriggerPriceBy { get; set; }

    /// <summary>
    /// The price type to trigger stop loss. MarkPrice, IndexPrice, default: LastPrice
    /// Valid for linear
    /// </summary>
    [JsonProperty("slTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? StopLossTriggerPriceBy { get; set; }

    /// <summary>
    /// What is a reduce-only order? true means your position can only reduce in size if this order is triggered.
    /// You must specify it as true when you are about to close/reduce the position
    /// When reduceOnly is true, take profit/stop loss cannot be set
    /// Valid for linear, &amp; option
    /// </summary>
    [JsonProperty("reduceOnly", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ReduceOnly { get; set; }

    /// <summary>
    /// What is a close on trigger order? For a closing order. It can only reduce your position, not increase it. If the account has insufficient available balance when the closing order is triggered, then other active orders of similar contracts will be cancelled or reduced. It can be used to ensure your stop loss reduces your position regardless of current available margin.
    /// Valid for linear
    /// </summary>
    [JsonProperty("closeOnTrigger", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CloseOnTrigger { get; set; }

    /// <summary>
    /// Smp execution type. What is SMP?
    /// </summary>
    [JsonProperty("smpType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitSelfMatchPrevention? SelfMatchPrevention { get; set; }

    /// <summary>
    /// Market maker protection. option only. true means set the order as a market maker protection order. What is mmp?
    /// </summary>
    [JsonProperty("mmp", NullValueHandling = NullValueHandling.Ignore)]
    public bool? MarketMakerProtection { get; set; }

    /// <summary>
    /// TP/SL mode
    /// Full: entire position for TP/SL. Then, tpOrderType or slOrderType must be Market
    /// Partial: partial position tp/sl (as there is no size option, so it will create tp/sl orders with the qty you actually fill). Limit TP/SL order are supported. Note: When create limit tp/sl, tpslMode is required and it must be Partial
    /// Valid for linear
    /// </summary>
    [JsonProperty("tpslMode", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// The limit order price when take profit price is triggered
    /// linear: only works when tpslMode=Partial and tpOrderType=Limit
    /// Spot(UTA): it is required when the order has takeProfit and tpOrderType=Limit
    /// </summary>
    [JsonProperty("tpLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// The limit order price when stop loss price is triggered
    /// linear: only works when tpslMode=Partial and slOrderType=Limit
    /// Spot(UTA): it is required when the order has stopLoss and slOrderType=Limit
    /// </summary>
    [JsonProperty("slLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLossLimitPrice { get; set; }

    /// <summary>
    /// The order type when take profit is triggered
    /// linear: Market(default), Limit. For tpslMode=Full, it only supports tpOrderType=Market
    /// Spot(UTA):
    /// Market: when you set "takeProfit",
    /// Limit: when you set "takeProfit" and "tpLimitPrice"
    /// </summary>
    [JsonProperty("tpOrderType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderType? TakeProfitOrderType { get; set; }

    /// <summary>
    /// The order type when stop loss is triggered
    /// linear: Market(default), Limit. For tpslMode=Full, it only supports slOrderType=Market
    /// Spot(UTA):
    /// Market: when you set "stopLoss",
    /// Limit: when you set "stopLoss" and "slLimitPrice"
    /// </summary>
    [JsonProperty("slOrderType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderType? StopLossOrderType { get; set; }
}
