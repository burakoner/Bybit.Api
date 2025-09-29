namespace Bybit.Api.Models.Socket;

/// <summary>
/// Bybit Net Asset Value Update
/// </summary>
public record BybitNetAssetValueUpdate
{
    /// <summary>
    /// The generated timestamp of nav
    /// </summary>
    [JsonProperty("time")]
    public long Timestamp { get; set; }

    /// <summary>
    /// The generated timestamp of nav
    /// </summary>
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Symbol name
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Net asset value
    /// </summary>
    [JsonProperty("nav")]
    public decimal NetAssetValue { get; set; }

    /// <summary>
    /// Basket
    /// </summary>
    public decimal Basket { get; set; }

    /// <summary>
    /// Basket loan
    /// </summary>
    public decimal BasketLoan { get; set; }

    /// <summary>
    /// Total position value = basket value * total circulation
    /// </summary>
    public decimal BasketPosition { get; set; }

    /// <summary>
    /// Circulation
    /// </summary>
    public decimal Circulation { get; set; }

    /// <summary>
    /// Leverage
    /// </summary>
    public decimal Leverage { get; set; }
}