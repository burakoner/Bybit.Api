namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Account Type
/// </summary>
public enum BybitAccountType
{
    /// <summary>
    /// Contract Account
    /// </summary>
    [Map("CONTRACT")]
    Contract = 1,
    
    /// <summary>
    /// Fund Account
    /// </summary>
    [Map("FUND")]
    Fund = 2,
    
    /// <summary>
    /// Option Account
    /// </summary>
    [Map("OPTION")]
    Option = 3,
    
    /// <summary>
    /// Spot Account
    /// </summary>
    [Map("SPOT")]
    Spot = 4,
    
    /// <summary>
    /// Unified Account
    /// </summary>
    [Map("UNIFIED")]
    Unified = 5,

    // [Map("INVESTMENT")]
    // Investment,
}