namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan maximum allowed collateral reduction amount.
/// </summary>
public record BybitCryptoLoanMaxCollateralAmount
{
    /// <summary>
    /// Maximum reduction amount.
    /// </summary>
    public decimal MaxCollateralAmount { get; set; }
}
