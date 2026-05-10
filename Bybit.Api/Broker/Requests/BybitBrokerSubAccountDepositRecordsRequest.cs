namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker subaccount deposit records request.
/// </summary>
public record BybitBrokerSubAccountDepositRecordsRequest
{
    /// <summary>
    /// Internal ID.
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    /// <summary>
    /// Transaction ID.
    /// </summary>
    [JsonProperty("txID", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Sub UID.
    /// </summary>
    [JsonProperty("subMemberId", NullValueHandling = NullValueHandling.Ignore)]
    public string? SubMemberId { get; set; }

    /// <summary>
    /// Coin.
    /// </summary>
    [JsonProperty("coin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Coin { get; set; }

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
    /// Limit for data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
