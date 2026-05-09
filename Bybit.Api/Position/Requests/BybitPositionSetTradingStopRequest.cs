namespace Bybit.Api.Position;

/// <summary>
/// Set trading stop request.
/// </summary>
public record BybitPositionSetTradingStopRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionSetTradingStopRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="positionIndex">Position index.</param>
    public BybitPositionSetTradingStopRequest(BybitCategory category, string symbol, BybitPositionIndex positionIndex)
    {
        Category = category;
        Symbol = symbol;
        PositionIndex = positionIndex;
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
    /// Position index.
    /// </summary>
    public BybitPositionIndex PositionIndex { get; set; }

    /// <summary>
    /// TP/SL mode.
    /// </summary>
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// Take profit trigger price type.
    /// </summary>
    public BybitTriggerPrice? TakeProfitTrigger { get; set; }

    /// <summary>
    /// Take profit order type.
    /// </summary>
    public BybitOrderType? TakeProfitOrderType { get; set; }

    /// <summary>
    /// Take profit price.
    /// </summary>
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Take profit limit price.
    /// </summary>
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// Take profit size.
    /// </summary>
    public decimal? TakeProfitQuantity { get; set; }

    /// <summary>
    /// Stop loss trigger price type.
    /// </summary>
    public BybitTriggerPrice? StopLossTrigger { get; set; }

    /// <summary>
    /// Stop loss order type.
    /// </summary>
    public BybitOrderType? StopLossOrderType { get; set; }

    /// <summary>
    /// Stop loss price.
    /// </summary>
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// Stop loss limit price.
    /// </summary>
    public decimal? StopLossLimitPrice { get; set; }

    /// <summary>
    /// Stop loss size.
    /// </summary>
    public decimal? StopLossQuantity { get; set; }

    /// <summary>
    /// Trailing stop distance.
    /// </summary>
    public decimal? TrailingStopDistance { get; set; }

    /// <summary>
    /// Trailing stop trigger price.
    /// </summary>
    public decimal? TrailingStopPrice { get; set; }
}
