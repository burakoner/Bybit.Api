namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Withdrawal Type
/// </summary>
public enum BybitWithdrawalType
{
    /// <summary>
    /// OnChain
    /// </summary>
    [Label("0")]
    OnChain,

    /// <summary>
    /// Offchain
    /// </summary>
    [Label("1")]
    Offchain,

    /// <summary>
    /// All
    /// </summary>
    [Label("2")]
    All,
}