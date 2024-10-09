namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Settlement Record
/// </summary>
public class BybitSettlementRecord
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Side
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Quantity
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Settlement Price
    /// </summary>
    [JsonProperty("sessionAvgPrice")]
    public decimal SettlementPrice { get; set; }

    /// <summary>
    /// Mark Price
    /// </summary>
    public decimal MarkPrice { get; set; }

    /// <summary>
    /// Realized PnL
    /// </summary>
    [JsonProperty("realisedPnl")]
    public decimal RealizedPnl { get; set; }

    /// <summary>
    /// Created time (ms)
    /// </summary>
    [JsonProperty("createdTime")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// Created time
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }
}
