namespace Bybit.Api.Spread;

/// <summary>
/// Spread cancel order request.
/// </summary>
public record BybitSpreadCancelOrderRequest
{
    /// <summary>
    /// Spread combination order ID.
    /// </summary>
    [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderId { get; set; }

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClientOrderId { get; set; }
}
