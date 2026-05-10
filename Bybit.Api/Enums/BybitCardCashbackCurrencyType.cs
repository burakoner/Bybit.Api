namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card cashback currency type.
/// </summary>
public enum BybitCardCashbackCurrencyType
{
    /// <summary>
    /// Fiat currency.
    /// </summary>
    [Map("FIAT")]
    Fiat,

    /// <summary>
    /// Crypto currency.
    /// </summary>
    [Map("CRYPTO")]
    Crypto,
}
