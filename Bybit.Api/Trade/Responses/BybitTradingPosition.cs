namespace Bybit.Api.Trade;

/// <summary>
/// Bybit Position
/// </summary>
public class BybitTradingPosition
{
    /// <summary>
    /// Position Index
    /// </summary>
    [JsonProperty("positionIdx")]
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
    [JsonProperty("tradeMode")]
    public BybitTradeMode TradeMode { get; set; }

    /// <summary>
    /// Whether to add margin automatically
    /// </summary>
    [JsonProperty("autoAddMargin")]
    public bool AutoAddMargin { get; set; }

    /// <summary>
    /// Position Status
    /// </summary>
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
    public BybitAdlRankIndicator? AdlRankIndicator { get; set; }
    
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
    /// Cross sequence, used to associate each fill and each position update
    /// Different symbols may have the same seq, please use seq + symbol to check unique
    /// Returns "-1" if the symbol has never been traded
    /// Returns the seq updated by the last transaction when there are settings like leverage, risk limit
    /// </summary>
    [JsonProperty("seq")]
    public long? CrossSequence { get; set; }
    
    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// true: Only allowed to reduce the position. You can consider a series of measures, e.g., lower the risk limit, decrease leverage or reduce the position, add margin, or cancel orders, after these operations, you can call confirm new risk limit endpoint to check if your position can be removed the reduceOnly mark
    /// false: There is no restriction, and it means your position is under the risk when the risk limit is systematically adjusted
    /// Only meaningful for isolated margin &amp; cross margin of USDT Perp, USDC Perp, USDC Futures, Inverse Perp and Inverse Futures, meaningless for others
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
}
