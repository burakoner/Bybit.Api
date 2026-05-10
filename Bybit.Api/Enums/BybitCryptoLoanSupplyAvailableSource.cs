namespace Bybit.Api.Enums;

/// <summary>
/// Source account for fixed crypto loan supply orders.
/// </summary>
public enum BybitCryptoLoanSupplyAvailableSource
{
    /// <summary>
    /// Funding account.
    /// </summary>
    [Map("0")]
    Funding = 0,

    /// <summary>
    /// Earn flexible account.
    /// </summary>
    [Map("1")]
    EarnFlexible = 1,

    /// <summary>
    /// All supported sources.
    /// </summary>
    [Map("2")]
    All = 2,
}
