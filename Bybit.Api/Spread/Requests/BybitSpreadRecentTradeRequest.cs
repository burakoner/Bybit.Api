namespace Bybit.Api.Spread;

/// <summary>
/// Spread recent public trade query request.
/// </summary>
public record BybitSpreadRecentTradeRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    public BybitSpreadRecentTradeRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}
