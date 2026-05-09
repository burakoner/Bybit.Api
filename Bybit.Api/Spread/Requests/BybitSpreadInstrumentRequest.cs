namespace Bybit.Api.Spread;

/// <summary>
/// Spread instrument query request.
/// </summary>
public record BybitSpreadInstrumentRequest
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string? Symbol { get; set; }

    /// <summary>
    /// Base asset.
    /// </summary>
    [JsonProperty("baseCoin", NullValueHandling = NullValueHandling.Ignore)]
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Pagination cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
