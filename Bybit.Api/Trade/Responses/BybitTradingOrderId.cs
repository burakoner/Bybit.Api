namespace Bybit.Api.Trade;

/// <summary>
/// Bybit Order Id
/// </summary>
public record BybitTradingOrderId
{
    /// <summary>
    /// Order Id
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Client Order Id
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;
}
