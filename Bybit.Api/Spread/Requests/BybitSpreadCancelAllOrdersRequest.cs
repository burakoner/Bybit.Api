namespace Bybit.Api.Spread;

/// <summary>
/// Spread cancel all orders request.
/// </summary>
public record BybitSpreadCancelAllOrdersRequest
{
    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string? Symbol { get; set; }

    /// <summary>
    /// Whether to cancel all spread orders across symbols.
    /// </summary>
    [JsonProperty("cancelAll", NullValueHandling = NullValueHandling.Ignore)]
    public bool? CancelAll { get; set; }
}
