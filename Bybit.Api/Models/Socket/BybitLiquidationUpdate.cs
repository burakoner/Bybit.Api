namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit Liquidation Stream
/// </summary>
public class BybitLiquidationUpdate
{
    /// <summary>
    /// The updated timestamp (ms)
    /// </summary>
    [JsonProperty("updateTime")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// The updated timestamp (ms)
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Position side. Buy,Sell. When you receive a Buy update, this means that a long position has been liquidated
    /// </summary>
    [JsonProperty("side")]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Executed size
    /// </summary>
    [JsonProperty("size")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Bankruptcy price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }
}
