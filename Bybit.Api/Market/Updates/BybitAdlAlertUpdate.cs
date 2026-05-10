namespace Bybit.Api.Market;

/// <summary>
/// Bybit ADL alert stream update.
/// </summary>
public record BybitAdlAlertUpdate
{
    /// <summary>
    /// Stream type.
    /// </summary>
    [JsonIgnore]
    public Bybit.Api.Common.Requests.BybitStreamType StreamType { get; set; }

    /// <summary>
    /// Stream generated timestamp in milliseconds.
    /// </summary>
    [JsonIgnore]
    public long StreamTimestamp { get; set; }

    /// <summary>
    /// Stream generated time.
    /// </summary>
    [JsonIgnore]
    public DateTime StreamTime { get => StreamTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Token of the insurance pool.
    /// </summary>
    [JsonProperty("c")]
    public string Coin { get; set; } = string.Empty;

    /// <summary>
    /// Trading pair name.
    /// </summary>
    [JsonProperty("s")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Balance of the insurance fund.
    /// </summary>
    [JsonProperty("b")]
    public decimal Balance { get; set; }

    /// <summary>
    /// Deprecated maximum balance of the insurance pool in the last 8 hours.
    /// </summary>
    [JsonProperty("mb")]
    public decimal? MaxBalance { get; set; }

    /// <summary>
    /// PnL ratio threshold for triggering contract PnL drawdown ADL.
    /// </summary>
    [JsonProperty("i_pr")]
    public decimal InsurancePnlRatio { get; set; }

    /// <summary>
    /// Symbol's PnL drawdown ratio in the last 8 hours.
    /// </summary>
    [JsonProperty("pr")]
    public decimal PnlRatio { get; set; }

    /// <summary>
    /// Trigger threshold for contract PnL drawdown ADL.
    /// </summary>
    [JsonProperty("adl_tt")]
    public decimal AdlTriggerThreshold { get; set; }

    /// <summary>
    /// Stop ratio threshold for contract PnL drawdown ADL.
    /// </summary>
    [JsonProperty("adl_sr")]
    public decimal AdlStopRatio { get; set; }
}
