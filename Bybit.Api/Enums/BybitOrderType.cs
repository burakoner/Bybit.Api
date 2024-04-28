namespace Bybit.Api.Enums;

/// <summary>
/// Bybit order type
/// </summary>
public enum BybitOrderType
{
    /// <summary>
    /// Limit order
    /// </summary>
    [Label("Limit")]
    Limit,

    /// <summary>
    /// Market order
    /// </summary>
    [Label("Market")]
    Market,

    /// <summary>
    /// Unknwn is not a valid request parameter value. Is only used in some responses. Mainly, it is used when execType is Funding.
    /// </summary>
    [Label("UNKNOWN")]
    Unknown,
}