namespace Bybit.Api.Spread;

/// <summary>
/// Bybit spread order ID result.
/// </summary>
public record BybitSpreadOrderId
{
    /// <summary>
    /// Spread combination order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Client order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;
}
