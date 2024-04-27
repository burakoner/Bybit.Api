namespace Bybit.Api.Models.Trade;

/// <summary>
/// Bybit Order Id
/// </summary>
public class BybitOrderId
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
