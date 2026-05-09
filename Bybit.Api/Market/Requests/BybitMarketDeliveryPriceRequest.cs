namespace Bybit.Api.Market;

/// <summary>
/// Request for delivery price.
/// </summary>
public record BybitMarketDeliveryPriceRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketDeliveryPriceRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketDeliveryPriceRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Base coin. Applies to options only.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Settle coin.
    /// </summary>
    public string? SettleAsset { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
