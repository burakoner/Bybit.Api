namespace Bybit.Api.Position;

/// <summary>
/// Set position leverage request.
/// </summary>
public record BybitPositionSetLeverageRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionSetLeverageRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    /// <param name="buyLeverage">Buy leverage.</param>
    /// <param name="sellLeverage">Sell leverage.</param>
    public BybitPositionSetLeverageRequest(BybitCategory category, string symbol, decimal buyLeverage, decimal sellLeverage)
    {
        Category = category;
        Symbol = symbol;
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
    /// Buy leverage.
    /// </summary>
    public decimal BuyLeverage { get; set; }

    /// <summary>
    /// Sell leverage.
    /// </summary>
    public decimal SellLeverage { get; set; }
}
