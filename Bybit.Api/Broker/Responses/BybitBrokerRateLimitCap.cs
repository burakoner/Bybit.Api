namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker rate limit cap.
/// </summary>
public record BybitBrokerRateLimitCap
{
    /// <summary>
    /// Business type.
    /// </summary>
    [JsonProperty("bizType")]
    public BybitBrokerBusinessType BusinessType { get; set; }

    /// <summary>
    /// Total API rate limit usage across all subaccounts and master account.
    /// </summary>
    public int TotalRate { get; set; }

    /// <summary>
    /// Entity-level API rate limit per second.
    /// </summary>
    public int EbCap { get; set; }

    /// <summary>
    /// UID-level API rate limit per second.
    /// </summary>
    public int UidCap { get; set; }
}
