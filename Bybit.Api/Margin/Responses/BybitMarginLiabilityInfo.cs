namespace Bybit.Api.Margin;

/// <summary>
/// Spot margin liability information.
/// </summary>
public record BybitMarginLiabilityInfo
{
    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Total liability.
    /// </summary>
    public decimal TotalBorrowAmount { get; set; }

    /// <summary>
    /// Fixed-rate liability.
    /// </summary>
    public decimal FixedBorrowAmount { get; set; }

    /// <summary>
    /// Floating-rate liability.
    /// </summary>
    public decimal FlexibleBorrowAmount { get; set; }

    /// <summary>
    /// Spot liability plus open order liability.
    /// </summary>
    public decimal SpotTotalBorrow { get; set; }

    /// <summary>
    /// Derivatives liability.
    /// </summary>
    public decimal DerivativesBorrow { get; set; }
}
