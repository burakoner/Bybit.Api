namespace Bybit.Api.Enums;

/// <summary>
/// Web3 quote mode.
/// </summary>
public enum BybitWeb3QuoteMode
{
    /// <summary>
    /// Auto mode.
    /// </summary>
    [Map("0")]
    Auto = 0,

    /// <summary>
    /// Price priority mode.
    /// </summary>
    [Map("1")]
    PricePriority = 1,

    /// <summary>
    /// Success rate priority mode.
    /// </summary>
    [Map("2")]
    SuccessRatePriority = 2,
}
