using System.Collections.Generic;
using System.Numerics;

namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit position update
/// </summary>
public class BybitPositionUpdate
{
    /// <summary>
    /// Product type
    /// </summary>
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }
    
    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Position side. Buy,Sell
    /// </summary>
    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }
    
    /// <summary>
    /// Position size
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Used to identify positions in different position modes
    /// </summary>
    [JsonProperty("positionIdx"), JsonConverter(typeof(LabelConverter<BybitPositionIndex>))]
    public BybitPositionIndex PositionIndex { get; set; }

    /// <summary>
    /// Trade mode
    /// </summary>
    [JsonProperty("tradeMode"), JsonConverter(typeof(LabelConverter<BybitTradeMode>))]
    public BybitTradeMode TradeMode { get; set; }

    /// <summary>
    /// Position value
    /// </summary>
    public decimal PositionValue { get; set; }

    /// <summary>
    /// Risk limit ID. Note: for portfolio margin mode, it returns 0, which the risk limit value is invalid
    /// </summary>
    public long RiskId { get; set; }

    /// <summary>
    /// Risk limit value corresponding to riskId. Note: for portfolio margin mode, it returns "", which the risk limit value is invalid
    /// </summary>
    public decimal? RiskLimitValue { get; set; }

    /// <summary>
    /// Entry price
    /// </summary>
    public decimal EntryPrice { get; set; }

    /// <summary>
    /// Mark price
    /// </summary>
    public decimal MarkPrice { get; set; }

    /// <summary>
    /// Leverage. Note: for portfolio margin mode, it returns "", which the leverage value is invalid
    /// </summary>
    public decimal? Leverage { get; set; }

    /// <summary>
    /// Position margin. For portfolio margin mode, it returns ""
    /// </summary>
    public decimal? PositionBalance { get; set; }

    /// <summary>
    /// Whether to add margin automatically. 0: false, 1: true. For UTA, it is meaningful only when UTA enables ISOLATED_MARGIN
    /// </summary>
    [JsonProperty("autoAddMargin"), JsonConverter(typeof(BooleanConverter))]
    public bool AutoAddMargin { get; set; }

    /// <summary>
    /// Position maintenance margin. Note: for portfolio margin mode, it returns ""
    /// </summary>
    public decimal? PositionMM { get; set; }

    /// <summary>
    /// Position initial margin. Note: for portfolio margin mode, it returns ""
    /// </summary>
    public decimal? PositionIM { get; set; }

    /// <summary>
    /// Position liquidation price
    /// </summary>
    public decimal? LiqPrice { get; set; }

    /// <summary>
    /// Est.bankruptcy price. "" for Unified trade(spot/linear/options)
    /// </summary>
    public decimal? BustPrice { get; set; }

    /// <summary>
    /// Depreciated, meaningless here, always "Full". Spot does not return this field. Option returns ""
    /// </summary>
    [JsonProperty("tpslMode"), JsonConverter(typeof(LabelConverter<BybitTakeProfitStopLossMode>))]
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// Take profit price
    /// </summary>
    public decimal? TakeProfit { get; set; }

    /// <summary>
    /// Stop loss price
    /// </summary>
    public decimal? StopLoss { get; set; }

    /// <summary>
    /// Trailing stop
    /// </summary>
    public decimal? TrailingStop { get; set; }

    /// <summary>
    /// Unrealised profit and loss
    /// </summary>
    public decimal? UnrealisedPnl { get; set; }

    /// <summary>
    /// The realised PnL for the current holding position
    /// </summary>
    [JsonProperty("curRealisedPnl")]
    public decimal CurrentRealisedPnl { get; set; }

    /// <summary>
    /// USDC contract session avg price, it is the same figure as avg entry price shown in the web UI
    /// </summary>
    public decimal? SessionAvgPrice { get; set; }

    /// <summary>
    /// Delta, unique field for option
    /// </summary>
    public decimal? delta { get; set; }

    /// <summary>
    /// Gamma, unique field for option
    /// </summary>
    public decimal? gamma { get; set; }

    /// <summary>
    /// Vega, unique field for option
    /// </summary>
    public decimal? vega { get; set; }

    /// <summary>
    /// Theta, unique field for option
    /// </summary>
    public decimal? theta { get; set; }

    /// <summary>
    /// Cumulative realised pnl
    /// Futures &amp; Perp: it is the all time cumulative realised P&amp;L
    /// Option: it is the realised P&amp;L when you hold that position
    /// </summary>
    [JsonProperty("cumRealisedPnl")]
    public decimal CumulativeRealisedPnl { get; set; }

    /// <summary>
    /// Position status. Normal, Liq, Adl
    /// </summary>
    [JsonProperty("positionStatus"), JsonConverter(typeof(LabelConverter<BybitPositionStatus>))]
    public BybitPositionStatus PositionStatus { get; set; }

    /// <summary>
    /// Auto-deleverage rank indicator.
    /// </summary>
    public int AdlRankIndicator { get; set; }

    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// </summary>
    public bool IsReduceOnly { get; set; }

    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// When isReduceOnly=true: the timestamp (ms) when the MMR will be forcibly adjusted by the system
    /// When isReduceOnly=false: the timestamp when the MMR had been adjusted by system
    /// It returns the timestamp when the system operates, and if you manually operate, there is no timestamp
    /// Keeps "" by default, if there was a lower risk limit system adjustment previously, it shows that system operation timestamp
    /// Only meaningful for isolated margin & cross margin of USDT Perp, USDC Perp, USDC Futures, Inverse Perp and Inverse Futures, meaningless for others
    /// </summary>
    [JsonProperty("mmrSysUpdatedTime")]
    public long? MmrSysUpdatedTimestamp { get; set; }
    
    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// When isReduceOnly=true: the timestamp (ms) when the MMR will be forcibly adjusted by the system
    /// When isReduceOnly=false: the timestamp when the MMR had been adjusted by system
    /// It returns the timestamp when the system operates, and if you manually operate, there is no timestamp
    /// Keeps "" by default, if there was a lower risk limit system adjustment previously, it shows that system operation timestamp
    /// Only meaningful for isolated margin & cross margin of USDT Perp, USDC Perp, USDC Futures, Inverse Perp and Inverse Futures, meaningless for others
    /// </summary>
    [JsonIgnore]
    public DateTime? MmrSysUpdatedTime { get { return MmrSysUpdatedTimestamp?.ConvertFromMilliseconds(); } }

    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// When isReduceOnly=true: the timestamp (ms) when the leverage will be forcibly adjusted by the system
    /// When isReduceOnly=false: the timestamp when the leverage had been adjusted by system
    /// It returns the timestamp when the system operates, and if you manually operate, there is no timestamp
    /// Keeps "" by default, if there was a lower risk limit system adjustment previously, it shows that system operation timestamp
    /// Only meaningful for isolated margin & cross margin of USDT Perp, USDC Perp, USDC Futures, Inverse Perp and Inverse Futures, meaningless for others
    /// </summary>
    [JsonProperty("leverageSysUpdatedTime")]
    public long? LeverageSysUpdatedTimestamp { get; set; }

    /// <summary>
    /// Useful when Bybit lower the risk limit
    /// When isReduceOnly=true: the timestamp (ms) when the leverage will be forcibly adjusted by the system
    /// When isReduceOnly=false: the timestamp when the leverage had been adjusted by system
    /// It returns the timestamp when the system operates, and if you manually operate, there is no timestamp
    /// Keeps "" by default, if there was a lower risk limit system adjustment previously, it shows that system operation timestamp
    /// Only meaningful for isolated margin & cross margin of USDT Perp, USDC Perp, USDC Futures, Inverse Perp and Inverse Futures, meaningless for others
    /// </summary>
    [JsonIgnore]
    public DateTime? LeverageSysUpdatedTime { get { return LeverageSysUpdatedTimestamp?.ConvertFromMilliseconds(); } }

    /// <summary>
    /// Timestamp of the first time a position was created on this symbol (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }

    /// <summary>
    /// Timestamp of the first time a position was created on this symbol
    /// </summary>
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Position data updated timestamp (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long? UpdatedTimestamp { get; set; }

    /// <summary>
    /// Position data updated timestamp
    /// </summary>
    public DateTime? UpdatedTime { get => UpdatedTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// Cross sequence, used to associate each fill and each position update
    /// Different symbols may have the same seq, please use seq + symbol to check unique
    /// Returns "-1" if the symbol has never been traded
    /// Returns the seq updated by the last transaction when there are setting like leverage, risk limit
    /// </summary>
    [JsonProperty("seq")]
    public long? Sequence { get; set; }
}