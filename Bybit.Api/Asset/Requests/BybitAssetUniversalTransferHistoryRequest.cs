namespace Bybit.Api.Asset;

/// <summary>
/// Universal transfer history request.
/// </summary>
public record BybitAssetUniversalTransferHistoryRequest
{
    /// <summary>
    /// Transfer ID.
    /// </summary>
    [JsonProperty("transferId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransferId { get; set; }

    /// <summary>
    /// Coin name, uppercase only.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Asset { get; set; }

    /// <summary>
    /// Transfer status.
    /// </summary>
    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    public BybitTransferStatus? Status { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? EndTime { get; set; }

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
