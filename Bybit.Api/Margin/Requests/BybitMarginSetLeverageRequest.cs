namespace Bybit.Api.Margin;

/// <summary>
/// Set spot margin leverage request.
/// </summary>
public record BybitMarginSetLeverageRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarginSetLeverageRequest"/> record.
    /// </summary>
    /// <param name="leverage">Leverage.</param>
    public BybitMarginSetLeverageRequest(decimal leverage)
    {
        Leverage = leverage;
    }

    /// <summary>
    /// Leverage.
    /// </summary>
    public decimal Leverage { get; set; }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string? Currency { get; set; }
}
