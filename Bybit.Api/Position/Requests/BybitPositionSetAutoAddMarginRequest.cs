namespace Bybit.Api.Position;

/// <summary>
/// Set auto-add-margin request.
/// </summary>
public record BybitPositionSetAutoAddMarginRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionSetAutoAddMarginRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="autoAddMargin">Auto-add-margin mode.</param>
    public BybitPositionSetAutoAddMarginRequest(BybitCategory category, string symbol, bool autoAddMargin)
    {
        Category = category;
        Symbol = symbol;
        AutoAddMargin = autoAddMargin;
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
    /// Auto-add-margin mode.
    /// </summary>
    public bool AutoAddMargin { get; set; }

    /// <summary>
    /// Position index.
    /// </summary>
    public BybitPositionIndex? PositionIndex { get; set; }
}
