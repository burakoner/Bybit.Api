namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker set rate limit request.
/// </summary>
public record BybitBrokerSetRateLimitRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBrokerSetRateLimitRequest"/> record.
    /// </summary>
    /// <param name="items">Rate limit items.</param>
    public BybitBrokerSetRateLimitRequest(IEnumerable<BybitBrokerSetRateLimitItem> items)
    {
        List = items?.ToList() ?? [];
    }

    /// <summary>
    /// Rate limit items.
    /// </summary>
    [JsonProperty("list")]
    public List<BybitBrokerSetRateLimitItem> List { get; set; }
}
