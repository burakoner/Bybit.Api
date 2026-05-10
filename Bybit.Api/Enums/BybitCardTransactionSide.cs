namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Card transaction side.
/// </summary>
public enum BybitCardTransactionSide
{
    /// <summary>
    /// Authorization.
    /// </summary>
    [Map("1")]
    Authorization = 1,

    /// <summary>
    /// Authorization reversal.
    /// </summary>
    [Map("2")]
    AuthorizationReversal = 2,

    /// <summary>
    /// Transaction.
    /// </summary>
    [Map("3")]
    Transaction = 3,

    /// <summary>
    /// Refund (unDeduct).
    /// </summary>
    [Map("4")]
    RefundUnDeduct = 4,

    /// <summary>
    /// Refund.
    /// </summary>
    [Map("5")]
    Refund = 5,

    /// <summary>
    /// Chargeback.
    /// </summary>
    [Map("6")]
    Chargeback = 6,

    /// <summary>
    /// Direct transaction.
    /// </summary>
    [Map("7")]
    DirectTransaction = 7,

    /// <summary>
    /// Refund reversal.
    /// </summary>
    [Map("8")]
    RefundReversal = 8,

    /// <summary>
    /// Chargeback reversal.
    /// </summary>
    [Map("9")]
    ChargebackReversal = 9,

    /// <summary>
    /// Refund request.
    /// </summary>
    [Map("10")]
    RefundRequest = 10,

    /// <summary>
    /// Refund reversal request.
    /// </summary>
    [Map("11")]
    RefundReversalRequest = 11,

    /// <summary>
    /// Chargeback fee.
    /// </summary>
    [Map("12")]
    ChargebackFee = 12,

    /// <summary>
    /// ATM withdrawal.
    /// </summary>
    [Map("13")]
    AtmWithdrawal = 13,
}
