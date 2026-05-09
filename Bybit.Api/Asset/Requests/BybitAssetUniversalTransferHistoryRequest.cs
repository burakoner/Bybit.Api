namespace Bybit.Api.Asset;

/// <summary>
/// Universal transfer history request.
/// </summary>
public record BybitAssetUniversalTransferHistoryRequest
{
    [JsonProperty("transferId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransferId { get; set; }

    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTransferStatus? Status { get; set; }

    [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? StartTime { get; set; }

    [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? EndTime { get; set; }

    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
