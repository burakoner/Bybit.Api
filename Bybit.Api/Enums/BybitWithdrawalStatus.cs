namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Withdrawal Status
/// </summary>
public enum BybitWithdrawalStatus
{
    /// <summary>
    /// Security Check
    /// </summary>
    [Label("SecurityCheck")]
    SecurityCheck,

    /// <summary>
    /// Pending
    /// </summary>
    [Label("Pending")]
    Pending,

    /// <summary>
    /// Success
    /// </summary>
    [Label("success")]
    Success,

    /// <summary>
    /// Canceled by user
    /// </summary>
    [Label("CancelByUser")]
    CanceledByUser,

    /// <summary>
    /// Rejected
    /// </summary>
    [Label("Reject")]
    Rejected,

    /// <summary>
    /// Failed
    /// </summary>
    [Label("Fail")]
    Failed,

    /// <summary>
    /// Blockchain confirmed
    /// </summary>
    [Label("BlockchainConfirmed")]
    BlockchainConfirmed,

    /// <summary>
    /// More information required
    /// </summary>
    [Label("MoreInformationRequired")]
    MoreInformationRequired,

    /// <summary>
    /// Unknown
    /// </summary>
    [Label("Unknown")]
    Unknown,
}