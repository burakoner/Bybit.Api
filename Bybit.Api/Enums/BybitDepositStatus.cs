namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Deposit Status
/// </summary>
public enum BybitDepositStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("0")]
    Unknown = 0,

    /// <summary>
    /// To Be Confirmed
    /// </summary>
    [Map("1")]
    ToBeConfirmed = 1,

    /// <summary>
    /// Processing
    /// </summary>
    [Map("2")]
    Processing = 2,

    /// <summary>
    /// Success
    /// </summary>
    [Map("3")]
    Success = 3,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("4")]
    Failed = 4,

    /// <summary>
    /// pending to be credited to funding pool
    /// </summary>
    [Map("10011")]
    PendingToBeCreditedToFundingPool = 10011,

    /// <summary>
    /// Credited to funding pool successfully
    /// </summary>
    [Map("10012")]
    CreditedToFundingPoolSuccessfully = 10012,
}