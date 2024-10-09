namespace Bybit.Api.Enums;

/// <summary>
/// Bybit order type
/// </summary>
public enum BybitOrderType
{
    /// <summary>
    /// Unknwn is not a valid request parameter value. Is only used in some responses. Mainly, it is used when execType is Funding.
    /// </summary>
    [Map("UNKNOWN")]
    Unknown = 0,

    /// <summary>
    /// Limit order
    /// </summary>
    [Map("Limit")]
    Limit = 1,

    /// <summary>
    /// Market order
    /// </summary>
    [Map("Market")]
    Market = 2,
}