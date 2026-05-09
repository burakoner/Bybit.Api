namespace Bybit.Api.Trading;

/// <summary>
/// Get spot borrow quota request.
/// </summary>
public record BybitBorrowQuotaRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBorrowQuotaRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="side">Transaction side.</param>
    public BybitBorrowQuotaRequest(BybitCategory category, string symbol, BybitOrderSide side)
    {
        Category = category;
        Symbol = symbol;
        Side = side;
    }

    /// <summary>
    /// Product type. Only spot is supported.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Transaction side.
    /// </summary>
    public BybitOrderSide Side { get; set; }
}
