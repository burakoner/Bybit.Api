namespace Bybit.Api.Enums;

/// <summary>
/// Institutional loan liquidation status.
/// </summary>
public enum BybitLoanLiquidationStatus
{
    /// <summary>
    /// Normal.
    /// </summary>
    [Map("0")]
    Normal = 0,

    /// <summary>
    /// Under liquidation.
    /// </summary>
    [Map("1")]
    UnderLiquidation = 1,

    /// <summary>
    /// Manual repayment in progress.
    /// </summary>
    [Map("2")]
    ManualRepaymentInProgress = 2,

    /// <summary>
    /// Transfer in progress.
    /// </summary>
    [Map("3")]
    TransferInProgress = 3,
}
