namespace Bybit.Api.Market;

/// <summary>
/// Request for recent public trades.
/// </summary>
public record BybitMarketTradingHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketTradingHistoryRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketTradingHistoryRequest(BybitCategory category)
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
    /// Option type. Applies to options only.
    /// </summary>
    public BybitOptionType? OptionType { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }
}
