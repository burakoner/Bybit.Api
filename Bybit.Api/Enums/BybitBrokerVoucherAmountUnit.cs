namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Broker voucher amount unit.
/// </summary>
public enum BybitBrokerVoucherAmountUnit
{
    /// <summary>
    /// Voucher amount is denominated in USD.
    /// </summary>
    [Map("AWARD_AMOUNT_UNIT_USD")]
    Usd,

    /// <summary>
    /// Voucher amount is denominated in coin.
    /// </summary>
    [Map("AWARD_AMOUNT_UNIT_COIN")]
    Coin,
}
