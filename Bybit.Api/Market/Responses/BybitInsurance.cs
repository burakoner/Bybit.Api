namespace Bybit.Api.Market;

/// <summary>
/// Bybit Insurance
/// </summary>
public class BybitInsurance
{
    /// <summary>
    /// Coin
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// For an independent insurance pool, you may see "BTCUSDT,ETHUSDT,SOLUSDT"
    /// For non-independent insurance pool, it returns ""
    /// </summary>
    public string Symbols { get; set; }

    /// <summary>
    /// Balance
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// USD value
    /// </summary>
    [JsonProperty("value")]
    public decimal Value { get; set; }
}