namespace Bybit.Api.Asset;

/// <summary>
/// Convert history request.
/// </summary>
public record BybitAssetConvertHistoryRequest
{
    [JsonProperty("accountType", NullValueHandling = NullValueHandling.Ignore)]
    public string? AccountType { get; set; }

    [JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
    public int? Index { get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}
