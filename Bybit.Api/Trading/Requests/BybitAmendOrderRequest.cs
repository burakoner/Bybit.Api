namespace Bybit.Api.Trading;

/// <summary>
/// Amend order request.
/// </summary>
public record BybitAmendOrderRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAmendOrderRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    public BybitAmendOrderRequest(BybitCategory category, string symbol)
    {
        Category = category;
        Symbol = symbol;
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
    /// Order ID. Either order ID or client order ID is required.
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// User customised order ID. Either order ID or client order ID is required.
    /// </summary>
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// Implied volatility.
    /// </summary>
    public decimal? OrderIv { get; set; }

    /// <summary>
    /// Order quantity after modification.
    /// </summary>
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Order price after modification.
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Trigger price.
    /// </summary>
    public decimal? TriggerPrice { get; set; }

    /// <summary>
    /// Trigger price type.
    /// </summary>
    public BybitTriggerPrice? TriggerBy { get; set; }

    /// <summary>
    /// TP/SL mode.
    /// </summary>
    public BybitTakeProfitStopLossMode? TakeProfitStopLossMode { get; set; }

    /// <summary>
    /// Take-profit trigger price type.
    /// </summary>
    public BybitTriggerPrice? TakeProfitTriggerBy { get; set; }

    /// <summary>
    /// Take-profit price after modification.
    /// </summary>
    public decimal? TakeProfitPrice { get; set; }

    /// <summary>
    /// Take-profit limit price.
    /// </summary>
    public decimal? TakeProfitLimitPrice { get; set; }

    /// <summary>
    /// Stop-loss trigger price type.
    /// </summary>
    public BybitTriggerPrice? StopLossTriggerBy { get; set; }

    /// <summary>
    /// Stop-loss price after modification.
    /// </summary>
    public decimal? StopLossPrice { get; set; }

    /// <summary>
    /// Stop-loss limit price.
    /// </summary>
    public decimal? StopLossLimitPrice { get; set; }
}
