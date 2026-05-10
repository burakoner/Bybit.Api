namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker rate limit setup item.
/// </summary>
public record BybitBrokerSetRateLimitItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBrokerSetRateLimitItem"/> record.
    /// </summary>
    /// <param name="uids">UIDs separated by commas.</param>
    /// <param name="businessType">Business type.</param>
    /// <param name="rate">API rate limit per second.</param>
    public BybitBrokerSetRateLimitItem(string uids, BybitBrokerBusinessType businessType, int rate)
    {
        Uids = uids;
        BusinessType = businessType;
        Rate = rate;
    }

    /// <summary>
    /// UIDs separated by commas.
    /// </summary>
    [JsonProperty("uids")]
    public string Uids { get; set; }

    /// <summary>
    /// Business type.
    /// </summary>
    [JsonProperty("bizType")]
    public BybitBrokerBusinessType BusinessType { get; set; }

    /// <summary>
    /// API rate limit per second.
    /// </summary>
    [JsonProperty("rate")]
    public int Rate { get; set; }
}
