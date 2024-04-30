namespace Bybit.Api.Models.Tokens;

/// <summary>
/// Bybit Leverage Token Market
/// </summary>
public class BybitLeverageTokenMarket
{
    /// <summary>
    /// Abbreviation of the LT, such as BTC3L
    /// </summary>
    [JsonProperty("ltCoin")]
    public string Symbol { get; set; }

    /// <summary>
    /// net value
    /// </summary>
    [JsonProperty("nav")]
    public decimal NetValue { get; set; }

    /// <summary>
    /// Update time for net asset value (in milliseconds and UTC time zone)
    /// </summary>
    [JsonProperty("navTime")]
    public long NetValueTimestamp { get; set; }

    /// <summary>
    /// Update time for net asset value (in milliseconds and UTC time zone)
    /// </summary>
    public DateTime NetValueTime { get => NetValueTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Circulating supply in the secondary market
    /// </summary>
    public decimal Circulation { get; set; }

    /// <summary>
    /// basket
    /// </summary>
    public decimal Basket { get; set; }

    /// <summary>
    /// Real leverage calculated by last traded price
    /// </summary>
    public decimal Leverage { get; set; }
}