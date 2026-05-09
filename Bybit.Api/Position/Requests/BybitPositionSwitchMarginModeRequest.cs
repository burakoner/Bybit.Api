namespace Bybit.Api.Position;

/// <summary>
/// Switch cross/isolated margin request.
/// </summary>
public record BybitPositionSwitchMarginModeRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionSwitchMarginModeRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="tradeMode">Trade mode.</param>
    /// <param name="buyLeverage">Buy leverage.</param>
    /// <param name="sellLeverage">Sell leverage.</param>
    public BybitPositionSwitchMarginModeRequest(BybitCategory category, string symbol, BybitTradeMode tradeMode, decimal buyLeverage, decimal sellLeverage)
    {
        Category = category;
        Symbol = symbol;
        TradeMode = tradeMode;
        BuyLeverage = buyLeverage;
        SellLeverage = sellLeverage;
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
    /// Trade mode.
    /// </summary>
    public BybitTradeMode TradeMode { get; set; }

    /// <summary>
    /// Buy leverage.
    /// </summary>
    public decimal BuyLeverage { get; set; }

    /// <summary>
    /// Sell leverage.
    /// </summary>
    public decimal SellLeverage { get; set; }
}
