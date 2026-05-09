namespace Bybit.Api.Account;

/// <summary>
/// Bybit account trade info for analysis request.
/// </summary>
public record BybitAccountTradeAnalysisRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountTradeAnalysisRequest"/> record.
    /// </summary>
    /// <param name="symbol">Symbol name.</param>
    public BybitAccountTradeAnalysisRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Query start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// Query end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }
}
