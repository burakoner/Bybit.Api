namespace Bybit.Api.Trade;

/// <summary>
/// Bybit Order Id
/// </summary>
public class BybitTradingOrderId
{
    /// <summary>
    /// Order Id
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// Client Order Id
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}
