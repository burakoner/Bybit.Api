namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert coin specification.
/// </summary>
public record BybitAssetConvertCoin
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Full coin name.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Coin icon URL.
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Dark-mode coin icon URL.
    /// </summary>
    public string IconNight { get; set; } = string.Empty;

    /// <summary>
    /// Coin precision.
    /// </summary>
    public int AccuracyLength { get; set; }

    /// <summary>
    /// Coin type.
    /// </summary>
    public string CoinType { get; set; } = string.Empty;

    /// <summary>
    /// Available balance returned by the convert coin list.
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// Coin balance in USDT value.
    /// </summary>
    [JsonProperty("uBalance")]
    public decimal? UsdBalance { get; set; }

    /// <summary>
    /// Minimum amount when this coin is used as the source coin.
    /// </summary>
    public decimal? SingleFromMinLimit { get; set; }

    /// <summary>
    /// Maximum amount when this coin is used as the source coin.
    /// </summary>
    public decimal? SingleFromMaxLimit { get; set; }

    /// <summary>
    /// Whether this coin is disabled as the source coin.
    /// </summary>
    public bool DisableFrom { get; set; }

    /// <summary>
    /// Whether this coin is disabled as the destination coin.
    /// </summary>
    public bool DisableTo { get; set; }

    /// <summary>
    /// Reserved time period value returned by Bybit.
    /// </summary>
    public int? TimePeriod { get; set; }

    /// <summary>
    /// Reserved minimum amount when this coin is used as the destination coin.
    /// </summary>
    public decimal? SingleToMinLimit { get; set; }

    /// <summary>
    /// Reserved maximum amount when this coin is used as the destination coin.
    /// </summary>
    public decimal? SingleToMaxLimit { get; set; }

    /// <summary>
    /// Reserved daily minimum amount when this coin is used as the source coin.
    /// </summary>
    public decimal? DailyFromMinLimit { get; set; }

    /// <summary>
    /// Reserved daily maximum amount when this coin is used as the source coin.
    /// </summary>
    public decimal? DailyFromMaxLimit { get; set; }

    /// <summary>
    /// Reserved daily minimum amount when this coin is used as the destination coin.
    /// </summary>
    public decimal? DailyToMinLimit { get; set; }

    /// <summary>
    /// Reserved daily maximum amount when this coin is used as the destination coin.
    /// </summary>
    public decimal? DailyToMaxLimit { get; set; }
}
