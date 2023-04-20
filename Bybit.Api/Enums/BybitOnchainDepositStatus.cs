namespace Bybit.Api.Enums;

public enum BybitOnchainDepositStatus
{
    [Label("0")]
    Unknown,

    [Label("1")]
    ToBeConfirmed,

    [Label("2")]
    Processing,

    [Label("3")]
    Success,

    [Label("4")]
    Failed,
}