namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Withdrawal Status
/// </summary>
public enum BybitWithdrawalStatus
{
    /// <summary>
    /// Unknown
    /// </summary>
    [Map("Unknown")]
    Unknown = 0,

    /// <summary>
    /// Security Check
    /// </summary>
    [Map("SecurityCheck")]
    SecurityCheck = 1,

    /// <summary>
    /// Pending
    /// </summary>
    [Map("Pending")]
    Pending = 2,

    /// <summary>
    /// Success
    /// </summary>
    [Map("success")]
    Success = 3,

    /// <summary>
    /// Canceled by user
    /// </summary>
    [Map("CancelByUser")]
    CanceledByUser = 4,

    /// <summary>
    /// Rejected
    /// </summary>
    [Map("Reject")]
    Rejected = 5,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("Fail")]
    Failed = 6,

    /// <summary>
    /// Blockchain confirmed
    /// </summary>
    [Map("BlockchainConfirmed")]
    BlockchainConfirmed = 7,

    /// <summary>
    /// More information required
    /// </summary>
    [Map("MoreInformationRequired")]
    MoreInformationRequired = 8,
}