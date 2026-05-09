namespace Bybit.Api.Asset;

/// <summary>
/// Coin exchange history request.
/// </summary>
public record BybitAssetExchangeHistoryRequest
{
    /// <summary>
    /// Coin to convert from.
    /// </summary>
    [JsonProperty("fromCoin", NullValueHandling = NullValueHandling.Ignore)]
    public string? FromAsset { get; set; }

    /// <summary>
    /// Coin to convert to.
    /// </summary>
    [JsonProperty("toCoin", NullValueHandling = NullValueHandling.Ignore)]
    public string? ToAsset { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Page cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
