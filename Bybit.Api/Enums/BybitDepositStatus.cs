namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Deposit Status
/// </summary>
public enum BybitDepositStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Label("0")]
    Unknown,

    /// <summary>
    /// To Be Confirmed
    /// </summary>
    [Label("1")]
    ToBeConfirmed,

    /// <summary>
    /// Processing
    /// </summary>
    [Label("2")]
    Processing,

    /// <summary>
    /// Success
    /// </summary>
    [Label("3")]
    Success,

    /// <summary>
    /// Failed
    /// </summary>
    [Label("4")]
    Failed,

    /// <summary>
    /// pending to be credited to funding pool
    /// </summary>
    [Label("10011")]
    PendingToBeCreditedToFundingPool,

    /// <summary>
    /// Credited to funding pool successfully
    /// </summary>
    [Label("10012")]
    CreditedToFundingPoolSuccessfully,
}