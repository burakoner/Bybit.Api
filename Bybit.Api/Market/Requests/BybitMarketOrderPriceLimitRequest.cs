namespace Bybit.Api.Market;

/// <summary>
/// Request for order price limit.
/// </summary>
public record BybitMarketOrderPriceLimitRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketOrderPriceLimitRequest"/> record.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    public BybitMarketOrderPriceLimitRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Product type. Defaults to linear on Bybit when not provided.
    /// </summary>
    public BybitCategory? Category { get; set; }
}
