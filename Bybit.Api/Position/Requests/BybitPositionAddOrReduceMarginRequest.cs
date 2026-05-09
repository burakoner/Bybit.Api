namespace Bybit.Api.Position;

/// <summary>
/// Add or reduce margin request.
/// </summary>
public record BybitPositionAddOrReduceMarginRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionAddOrReduceMarginRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="margin">Margin amount.</param>
    public BybitPositionAddOrReduceMarginRequest(BybitCategory category, string symbol, decimal margin)
    {
        Category = category;
        Symbol = symbol;
        Margin = margin;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Margin amount.
    /// </summary>
    public decimal Margin { get; set; }

    /// <summary>
    /// Position index.
    /// </summary>
    public BybitPositionIndex? PositionIndex { get; set; }
}
