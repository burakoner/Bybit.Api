namespace Bybit.Api.Spread;

/// <summary>
/// Spread open order query request.
/// </summary>
public record BybitSpreadOrderQueryRequest
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
    /// Spread combination order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClientOrderId { get; set; }

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
