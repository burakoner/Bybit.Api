namespace Bybit.Api.Enums;

/// <summary>
/// Web3 token risk flag.
/// </summary>
public enum BybitWeb3RiskFlag
{
    /// <summary>
    /// No risk identified.
    /// </summary>
    [Map("0")]
    NoRisk = 0,

    /// <summary>
    /// Risk identified.
    /// </summary>
    [Map("1")]
    RiskIdentified = 1,
}
