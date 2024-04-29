namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Account Type
/// </summary>
public enum BybitAccount
{
    /// <summary>
    /// Contract Account
    /// </summary>
    [Label("CONTRACT")]
    Contract,
    
    /// <summary>
    /// Fund Account
    /// </summary>
    [Label("FUND")]
    Fund,
    
    /// <summary>
    /// Option Account
    /// </summary>
    [Label("OPTION")]
    Option,
    
    /// <summary>
    /// Spot Account
    /// </summary>
    [Label("SPOT")]
    Spot,
    
    /// <summary>
    /// Unified Account
    /// </summary>
    [Label("UNIFIED")]
    Unified,

    // [Label("INVESTMENT")]
    // Investment,
}