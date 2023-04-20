namespace Bybit.Api.Enums;

public enum BybitInternalDepositStatus
{
    [Label("0")]
    Unknown,

    [Label("1")]
    Processing,

    [Label("2")]
    Success,

    [Label("3")]
    Failed,
}