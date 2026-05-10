namespace Bybit.Api.Enums;

/// <summary>
/// Refund account for fixed crypto loan supply order cancellation.
/// </summary>
public enum BybitCryptoLoanRefundedAccount
{
    /// <summary>
    /// Funding account.
    /// </summary>
    [Map("0")]
    Funding = 0,

    /// <summary>
    /// Easy Earn.
    /// </summary>
    [Map("1")]
    EasyEarn = 1,
}
