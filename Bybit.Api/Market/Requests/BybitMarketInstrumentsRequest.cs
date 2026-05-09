namespace Bybit.Api.Market;

/// <summary>
/// Request for market instrument info endpoints.
/// </summary>
public record BybitMarketInstrumentsRequest
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Symbol status filter.
    /// </summary>
    public BybitInstrumentStatus? Status { get; set; }

    /// <summary>
    /// The region to which the trading pair belongs.
    /// </summary>
    public BybitInstrumentType? SymbolType { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 500;

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}
