namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker all rate limits request.
/// </summary>
public record BybitBrokerRateLimitsRequest
{
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

    /// <summary>
    /// UIDs separated by commas.
    /// </summary>
    [JsonProperty("uids", NullValueHandling = NullValueHandling.Ignore)]
    public string? Uids { get; set; }
}
