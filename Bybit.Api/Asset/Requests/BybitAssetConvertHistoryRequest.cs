namespace Bybit.Api.Asset;

/// <summary>
/// Convert history request.
/// </summary>
public record BybitAssetConvertHistoryRequest
{
    /// <summary>
    /// Convert wallet type.
    /// </summary>
    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public string? AccountType { get; set; }

    /// <summary>
    /// Page index.
    /// </summary>
    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    public int? Index { get; set; }

    /// <summary>
    /// Page size.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}
