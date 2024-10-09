namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Withdrawal Type
/// </summary>
public enum BybitWithdrawalType
{
    /// <summary>
    /// OnChain
    /// </summary>
    [Map("0")]
    OnChain = 0,

    /// <summary>
    /// Offchain
    /// </summary>
    [Map("1")]
    Offchain = 1,

    /// <summary>
    /// All
    /// </summary>
    [Map("2")]
    All = 2,
}