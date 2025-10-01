namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Instrument Type
/// </summary>
public enum BybitInstrumentType
{
    /// <summary>
    /// Pre Launch
    /// </summary>
    [Map("innovation")]
    Innovation = 1,

    /// <summary>
    /// adventure
    /// </summary>
    [Map("adventure")]
    Adventure = 2,

    /// <summary>
    /// xstocks
    /// </summary>
    [Map("xstocks")]
    XStocks = 3,
}