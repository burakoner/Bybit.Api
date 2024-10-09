namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Sub Account Type
/// </summary>
public enum BybitSubAccountType
{
    /// <summary>
    /// Normal Sub Account
    /// </summary>
    [Map("1")]
    NormalSubAccount = 1,

    /// <summary>
    /// Custodial Sub Account
    /// </summary>
    [Map("6")]
    CustodialSubAccount = 6,
}