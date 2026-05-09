namespace Bybit.Api.Trading;

/// <summary>
/// Bybit pre-check order result.
/// </summary>
public record BybitPreCheckOrder
{
    /// <summary>
    /// Order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// User customised order ID.
    /// </summary>
    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; } = string.Empty;

    /// <summary>
    /// Initial margin rate before checking, scaled by 1e4.
    /// </summary>
    [JsonProperty("preImrE4")]
    public int? PreInitialMarginRateE4 { get; set; }

    /// <summary>
    /// Maintenance margin rate before checking, scaled by 1e4.
    /// </summary>
    [JsonProperty("preMmrE4")]
    public int? PreMaintenanceMarginRateE4 { get; set; }

    /// <summary>
    /// Initial margin rate after checking, scaled by 1e4.
    /// </summary>
    [JsonProperty("postImrE4")]
    public int? PostInitialMarginRateE4 { get; set; }

    /// <summary>
    /// Maintenance margin rate after checking, scaled by 1e4.
    /// </summary>
    [JsonProperty("postMmrE4")]
    public int? PostMaintenanceMarginRateE4 { get; set; }
}
