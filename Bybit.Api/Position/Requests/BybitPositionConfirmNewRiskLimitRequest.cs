namespace Bybit.Api.Position;

/// <summary>
/// Confirm new risk limit request.
/// </summary>
public record BybitPositionConfirmNewRiskLimitRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionConfirmNewRiskLimitRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="symbol">Symbol name.</param>
    public BybitPositionConfirmNewRiskLimitRequest(BybitCategory category, string symbol)
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
}
