namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card point records request.
/// </summary>
public record BybitCardPointRecordsRequest
{
    /// <summary>
    /// Point type filter.
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string? Type { get; set; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; }

    /// <summary>
    /// Page number.
    /// </summary>
    [JsonProperty("pageNo", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageNo { get; set; }

    /// <summary>
    /// Start time.
    /// </summary>
    [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? StartTime { get; set; }

    /// <summary>
    /// End time.
    /// </summary>
    [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? EndTime { get; set; }

    /// <summary>
    /// External order ID.
    /// </summary>
    [JsonProperty("outOrderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OutOrderId { get; set; }

    /// <summary>
    /// Point order ID.
    /// </summary>
    [JsonProperty("bizId", NullValueHandling = NullValueHandling.Ignore)]
    public string? BusinessId { get; set; }

    /// <summary>
    /// Consume ID lifecycle.
    /// </summary>
    [JsonProperty("bizTxnId", NullValueHandling = NullValueHandling.Ignore)]
    public string? BusinessTransactionId { get; set; }

    /// <summary>
    /// Point direction.
    /// </summary>
    [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardPointSide? Side { get; set; }
}
