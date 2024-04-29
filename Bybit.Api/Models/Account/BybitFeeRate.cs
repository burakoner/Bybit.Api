namespace Bybit.Api.Models.Account;

/// <summary>
/// Fee info
/// </summary>
public class BybitFeeRate
{
    /// <summary>
    /// Symbol
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Base asset
    /// </summary>
    [JsonProperty("baseCoin")]
    public string BaseAsset { get; set; }

    /// <summary>
    /// Taker fee rate
    /// </summary>
    public decimal TakerFeeRate { get; set; }

    /// <summary>
    /// Maker fee rate
    /// </summary>
    public decimal MakerFeeRate { get; set; }
}
