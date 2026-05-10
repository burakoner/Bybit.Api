namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker earnings request.
/// </summary>
public record BybitBrokerEarningsRequest
{
    /// <summary>
    /// Business type.
    /// </summary>
    [JsonProperty("bizType", NullValueHandling = NullValueHandling.Ignore)]
    public BybitBrokerBusinessType? BusinessType { get; set; }

    /// <summary>
    /// Begin date in YYYYMMDD format.
    /// </summary>
    [JsonProperty("begin", NullValueHandling = NullValueHandling.Ignore)]
    public string? Begin { get; set; }

    /// <summary>
    /// End date in YYYYMMDD format.
    /// </summary>
    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string? End { get; set; }

    /// <summary>
    /// Subaccount UID.
    /// </summary>
    [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
    public string? Uid { get; set; }

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
