namespace Bybit.Api.Trading;

/// <summary>
/// Place order request.
/// </summary>
public record BybitPlaceOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPlaceOrderRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="side">Order side.</param>
    /// <param name="type">Order type.</param>
    /// <param name="quantity">Order quantity.</param>
    public BybitPlaceOrderRequest(BybitCategory category, string symbol, BybitOrderSide side, BybitOrderType type, decimal quantity)
    {
        Category = category;
        Symbol = symbol;
        Side = side;
        Type = type;
        Quantity = quantity;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    [JsonProperty("category")]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Order side.
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order type.
    /// </summary>
    [JsonProperty("orderType")]
    public BybitOrderType Type { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Unit for spot market order quantity.
    /// </summary>
    [JsonProperty("marketUnit", NullValueHandling = NullValueHandling.Ignore)]
    public BybitUnit? MarketUnit { get; set; }

    /// <summary>
    /// Order price.
    /// </summary>
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? Price { get; set; }

    /// <summary>
    /// User customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Whether to borrow for spot margin.
    /// </summary>
    [JsonIgnore]
    public bool? IsLeverage
    {
        get => IsLeverageField == null ? null : IsLeverageField == 1;
        set => IsLeverageField = value == null ? null : value.Value ? 1 : 0;
    }

    /// <summary>
    /// Whether to borrow for spot margin.
    /// </summary>
    [JsonProperty("isLeverage", NullValueHandling = NullValueHandling.Ignore)]
    public int? IsLeverageField { get; private set; }

    /// <summary>
    /// Slippage tolerance type for market order.
    /// </summary>
    [JsonProperty("slippageToleranceType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitSlippageToleranceType? SlippageToleranceType { get; set; }

    /// <summary>
    /// Slippage tolerance value.
    /// </summary>
    [JsonProperty("slippageTolerance", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? SlippageTolerance { get; set; }

    /// <summary>
    /// Conditional order trigger direction.
    /// </summary>
    [JsonProperty("triggerDirection", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerDirection? TriggerDirection { get; set; }

    /// <summary>
    /// Spot order filter.
    /// </summary>
    [JsonProperty("orderFilter", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderFilter? OrderFilter { get; set; }

    /// <summary>
    /// Trigger price.
    /// </summary>
    [JsonProperty("triggerPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Trigger price type.
    /// </summary>
    [JsonProperty("triggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TriggerBy { get; set; }

    /// <summary>
    /// Implied volatility.
    /// </summary>
    [JsonProperty("orderIv", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? OrderIv { get; set; }

    /// <summary>
    /// Time in force.
    /// </summary>
    [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTimeInForce? TimeInForce { get; set; }

    /// <summary>
    /// Position index.
    /// </summary>
    [JsonProperty("positionIdx", NullValueHandling = NullValueHandling.Ignore)]
    public BybitPositionIndex? PositionIndex { get; set; }

    /// <summary>
    /// Reduce only.
    /// </summary>
    [JsonProperty("reduceOnly", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ReduceOnly { get; set; }

    /// <summary>
    /// Close on trigger.
    /// </summary>
    [JsonProperty("closeOnTrigger", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CloseOnTrigger { get; set; }

    /// <summary>
    /// Market maker protection.
    /// </summary>
    [JsonProperty("mmp", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Mmp { get; set; }

    /// <summary>
    /// SMP execution type.
    /// </summary>
    [JsonProperty("smpType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitSelfMatchPrevention? SelfMatchPrevention { get; set; }

    /// <summary>
    /// TP/SL mode.
    /// </summary>
    [JsonProperty("tpslMode", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// Take-profit order type.
    /// </summary>
    [JsonProperty("tpOrderType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderType? TakeProfitOrderType { get; set; }

    /// <summary>
    /// Take-profit trigger price type.
    /// </summary>
    [JsonProperty("tpTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? TakeProfitTriggerBy { get; set; }

    /// <summary>
    /// Take-profit price.
    /// </summary>
    [JsonProperty("takeProfit", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Take-profit limit price.
    /// </summary>
    [JsonProperty("tpLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// Stop-loss order type.
    /// </summary>
    [JsonProperty("slOrderType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitOrderType? StopLossOrderType { get; set; }

    /// <summary>
    /// Stop-loss trigger price type.
    /// </summary>
    [JsonProperty("slTriggerBy", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTriggerPrice? StopLossTriggerBy { get; set; }

    /// <summary>
    /// Stop-loss price.
    /// </summary>
    [JsonProperty("stopLoss", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// Stop-loss limit price.
    /// </summary>
    [JsonProperty("slLimitPrice", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal? StopLossLimitPrice { get; set; }

    /// <summary>
    /// Best bid/offer side type.
    /// </summary>
    [JsonProperty("bboSideType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitBboSideType? BboSideType { get; set; }

    /// <summary>
    /// Best bid/offer level.
    /// </summary>
    [JsonProperty("bboLevel", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerToStringConverter))]
    public int? BboLevel { get; set; }
}
