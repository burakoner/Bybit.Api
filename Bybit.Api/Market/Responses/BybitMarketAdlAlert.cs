namespace Bybit.Api.Market;

/// <summary>
/// Bybit ADL alert information.
/// </summary>
public record BybitMarketAdlAlert
{
    /// <summary>
    /// Latest data update timestamp in milliseconds.
    /// </summary>
    [JsonProperty("updatedTime")]
    public long? UpdateTimestamp { get; set; }

    /// <summary>
    /// Latest data update time.
    /// </summary>
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }

    /// <summary>
    /// ADL alert list.
    /// </summary>
    public List<BybitMarketAdlAlertItem> List { get; set; } = [];
}

/// <summary>
/// Bybit ADL alert item.
/// </summary>
public record BybitMarketAdlAlertItem
{
    /// <summary>
    /// Token of the insurance pool.
    /// </summary>
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Trading pair name.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Balance of the insurance fund.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Deprecated maximum balance of the insurance pool in the last 8 hours.
    /// </summary>
    public decimal? MaxBalance { get; set; }

    /// <summary>
    /// PnL ratio threshold for triggering contract PnL drawdown ADL.
    /// </summary>
    public decimal InsurancePnlRatio { get; set; }

    /// <summary>
    /// Symbol's PnL drawdown ratio in the last 8 hours.
    /// </summary>
    public decimal PnlRatio { get; set; }

    /// <summary>
    /// Trigger threshold for contract PnL drawdown ADL.
    /// </summary>
    public decimal AdlTriggerThreshold { get; set; }

    /// <summary>
    /// Stop ratio threshold for contract PnL drawdown ADL.
    /// </summary>
    public decimal AdlStopRatio { get; set; }
}
