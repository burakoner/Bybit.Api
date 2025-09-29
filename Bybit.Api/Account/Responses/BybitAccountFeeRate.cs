namespace Bybit.Api.Account;

/// <summary>
/// Fee info
/// </summary>
public class BybitAccountFeeRate
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Base asset
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; } = string.Empty;

    /// <summary>
    /// Taker fee rate
    /// </summary>
    public decimal TakerFeeRate { get; set; }

    /// <summary>
    /// Maker fee rate
    /// </summary>
    public decimal MakerFeeRate { get; set; }
}
