namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Crypto loan collateral adjustment ID.
/// </summary>
public record BybitCryptoLoanAdjustmentId
{
    /// <summary>
    /// Collateral adjustment transaction ID.
    /// </summary>
    public long AdjustId { get; set; }
}
