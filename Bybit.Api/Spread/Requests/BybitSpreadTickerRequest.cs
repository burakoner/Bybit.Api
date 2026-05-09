namespace Bybit.Api.Spread;

/// <summary>
/// Spread ticker query request.
/// </summary>
public record BybitSpreadTickerRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="symbol">Spread combination symbol name.</param>
    public BybitSpreadTickerRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Spread combination symbol name.
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
}
