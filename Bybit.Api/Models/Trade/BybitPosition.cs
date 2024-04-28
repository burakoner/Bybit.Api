namespace Bybit.Api.Models.Trade;

/// <summary>
/// Bybit Position
/// </summary>
public class BybitPosition
{
    /// <summary>
    /// Position Index
    /// </summary>
    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex PositionIndex { get; set; }

    /// <summary>
    /// Risk Id
    /// </summary>
    public long RiskId { get; set; }

    /// <summary>
    /// Risk Limit Value
    /// </summary>
    public decimal RiskLimitValue { get; set; }

    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitPositionSide>))]
    public BybitPositionSide? Side { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Average entry price
    /// </summary>
    [JsonProperty("avgPrice")]
    public decimal? AveragePrice { get; set; }

    /// <summary>
    /// Position Value
    /// </summary>
    public decimal? PositionValue { get; set; }

    /// <summary>
    /// Trade Mode
    /// </summary>
    [JsonProperty("tradeMode"), JsonConverter(typeof(LabelConverter<BybitTradeMode>))]
    public BybitTradeMode TradeMode { get; set; }

    /// <summary>
    /// Whether to add margin automatically
    /// </summary>
    [JsonProperty("autoAddMargin")]
    public bool AutoAddMargin { get; set; }

    /// <summary>
    /// Position Status
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitPositionStatus>))]
    public BybitPositionStatus PositionStatus { get; set; }

    /// <summary>
    /// Leverage
    /// </summary>
    public decimal? Leverage { get; set; }

    /// <summary>
    /// Mark Price
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Liquidation Price
    /// </summary>
    [JsonProperty("liqPrice")]
    public decimal? LiquidationPrice { get; set; }

    /// <summary>
    /// Bust Price
    /// </summary>
    public decimal? BustPrice { get; set; }

    /// <summary>
    /// Initial Margin
    /// </summary>
    [JsonProperty("positionIM")]
    public decimal? InitialMargin { get; set; }

    /// <summary>
    /// Maintenance Margin
    /// </summary>
    [JsonProperty("positionMM")]
    public decimal? MaintenanceMargin { get; set; }

    /// <summary>
    /// Position Balance
    /// </summary>
    [JsonProperty("positionBalance")]
    public decimal? PositionBalance { get; set; }

    /// <summary>
    /// Depreciated, meaningless here, always "Full". Spot does not return this field. Option returns ""
    /// </summary>
    [JsonProperty("tpslMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// Take Profit Price
    /// </summary>
    [JsonProperty("takeProfit")]
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Stop Loss Price
    /// </summary>
    [JsonProperty("stopLoss")]
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// Trailing Stop Distance
    /// </summary>
    [JsonProperty("trailingStop")]
    public decimal? TrailingStopDistance { get; set; }

    /// <summary>
    /// USDC contract session average price, it is the same figure as avg entry price shown in the web UI
    /// </summary>
    [JsonProperty("sessionAvgPrice")]
    public decimal? SessionAveragePrice { get; set; }

    /// <summary>
    /// Delta, unique field for option
    /// </summary>
    [JsonProperty("delta")]
    public decimal? Delta { get; set; }

    /// <summary>
    /// Gamma, unique field for option
    /// </summary>
    [JsonProperty("gamma")]
    public decimal? Gamma { get; set; }

    /// <summary>
    /// Vega, unique field for option
    /// </summary>
    [JsonProperty("vega")]
    public decimal? Vega { get; set; }

    /// <summary>
    /// Theta, unique field for option
    /// </summary>
    [JsonProperty("theta")]
    public decimal? Theta { get; set; }

    /// <summary>
    /// Unrealised PnL
    /// </summary>
    [JsonProperty("unrealisedPnl")]
    public decimal? UnrealizedPnl { get; set; }

    /// <summary>
    /// The realised PnL for the current holding position
    /// </summary>
    [JsonProperty("curRealisedPnl")]
    public decimal? CurrentRealizedPnl { get; set; }

    /// <summary>
    /// Cumulative realised pnl
    /// </summary>
    [JsonProperty("cumRealisedPnl")]
    public decimal? CumulativeRealizedPnl { get; set; }

    /// <summary>
    /// Auto-deleverage rank indicator. 
    /// </summary>
    [JsonProperty("adlRankIndicator")]
    public int AutoDeleverageRankIndicator { get; set; }

    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// </summary>
    [JsonProperty("isReduceOnly")]
    public bool? IsReduceOnly { get; set; }

    /// <summary>
    /// When IsReduceOnly = true: the timestamp when the MMR will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the MMR had been adjusted by system
    /// </summary>
    [JsonProperty("mmrSysUpdatedTime")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? MaintenanceMarginUpdateTime { get; set; }

    /// <summary>
    /// When IsReduceOnly = true: the timestamp when the leverage will be forcibly adjusted by the system. When IsReduceOnly = false: the timestamp when the leverage had been adjusted by system
    /// </summary>
    [JsonProperty("leverageSysUpdatedTime")]
    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LeverageUpdateTime { get; set; }

    /// <summary>
    /// Timestamp of the first time a position was created on this symbol (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Timestamp of the first time a position was created on this symbol
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Position updated timestamp (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }

    /// <summary>
    /// Position updated timestamp
    /// </summary>
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Refer to the cursor request parameter
    /// </summary>
    public string NextPageCursor { get; set; }
}
