namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert coin specification.
/// </summary>
public record BybitAssetConvertCoin
{
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string IconNight { get; set; } = string.Empty;
    public int AccuracyLength { get; set; }
    public string CoinType { get; set; } = string.Empty;
    public decimal? Balance { get; set; }

    [JsonProperty("uBalance")]
    public decimal? UsdBalance { get; set; }

    public decimal? SingleFromMinLimit { get; set; }
    public decimal? SingleFromMaxLimit { get; set; }
    public bool DisableFrom { get; set; }
    public bool DisableTo { get; set; }
    public int? TimePeriod { get; set; }
    public decimal? SingleToMinLimit { get; set; }
    public decimal? SingleToMaxLimit { get; set; }
    public decimal? DailyFromMinLimit { get; set; }
    public decimal? DailyFromMaxLimit { get; set; }
    public decimal? DailyToMinLimit { get; set; }
    public decimal? DailyToMaxLimit { get; set; }
}
