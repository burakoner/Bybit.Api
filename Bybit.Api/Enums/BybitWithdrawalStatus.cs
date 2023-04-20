namespace Bybit.Api.Enums;

public enum BybitWithdrawalStatus
{
    [Label("SecurityCheck")]
    SecurityCheck,

    [Label("Pending")]
    Pending,

    [Label("success")]
    Success,

    [Label("CancelByUser")]
    CanceledByUser,

    [Label("Reject")]
    Rejected,

    [Label("Fail")]
    Failed,

    [Label("BlockchainConfirmed")]
    BlockchainConfirmed,
}