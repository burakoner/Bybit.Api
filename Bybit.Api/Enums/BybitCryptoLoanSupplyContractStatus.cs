namespace Bybit.Api.Enums;

/// <summary>
/// Fixed crypto loan supply contract status.
/// </summary>
public enum BybitCryptoLoanSupplyContractStatus
{
    /// <summary>
    /// Supplying.
    /// </summary>
    [Map("1")]
    Supplying = 1,

    /// <summary>
    /// Redeemed.
    /// </summary>
    [Map("2")]
    Redeemed = 2,
}
