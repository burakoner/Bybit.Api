namespace Bybit.Api.Spread;

/// <summary>
/// Spread orderbook query request.
/// </summary>
public record BybitSpreadOrderbookRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    public BybitSpreadOrderbookRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    /// <summary>
    /// Limit size for each bid and ask.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}
