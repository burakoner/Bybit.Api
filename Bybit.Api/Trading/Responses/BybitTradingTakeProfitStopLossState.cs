namespace Bybit.Api.Trading;

/// <summary>
/// Bybit Take Profit Stop Loss State
/// </summary>
public record BybitTradingTakeProfitStopLossState
{
    /// <summary>
    /// Take Profit Stop Loss Mode
    /// </summary>
    [JsonProperty("tpSlMode")]
    public BybitTakeProfitStopLossMode TakeProfitStopLossMode { get; set; }
}
