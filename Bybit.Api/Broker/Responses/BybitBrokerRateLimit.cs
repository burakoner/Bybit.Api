namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker rate limit.
/// </summary>
public record BybitBrokerRateLimit
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
}
