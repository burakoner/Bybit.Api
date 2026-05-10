namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker set rate limit result.
/// </summary>
public record BybitBrokerRateLimitSetResult
{
    /// <summary>
    /// UIDs separated by commas.
    /// </summary>
    public string Uids { get; set; } = string.Empty;

    /// <summary>
    /// Business type.
    /// </summary>
    [JsonProperty("bizType")]
    public BybitBrokerBusinessType BusinessType { get; set; }

    /// <summary>
    /// API rate limit per second.
    /// </summary>
    public int Rate { get; set; }

    /// <summary>
    /// Whether the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Result message.
    /// </summary>
    [JsonProperty("msg")]
    public string Message { get; set; } = string.Empty;
}
