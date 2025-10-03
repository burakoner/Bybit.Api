namespace Bybit.Api.Account;

/// <summary>
/// Bybit Account Information
/// </summary>
public record BybitAccount
{
    /// <summary>
    /// Account status
    /// </summary>
    public BybitUnifiedMarginStatus UnifiedMarginStatus { get; set; }

    /// <summary>
    /// ISOLATED_MARGIN, REGULAR_MARGIN, PORTFOLIO_MARGIN
    /// </summary>
    public BybitMarginMode MarginMode { get; set; }

    /// <summary>
    /// Whether the account is a master trader (copytrading). true, false
    /// </summary>
    public bool IsMasterTrader { get; set; }

    /// <summary>
    /// Whether the unified account enables Spot hedging. ON, OFF
    /// </summary>
    public string SpotHedgingStatus { get; set; } = "";

    /// <summary>
    /// Account data updated timestamp (ms)
    /// </summary>
    [JsonProperty("updatedTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// Account data updated timestamp
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }
}
