namespace Bybit.Api.Enums;

public enum BybitWithdrawalType
{
    [Label("0")]
    OnChain,

    [Label("1")]
    Offchain,

    [Label("2")]
    All,
}