namespace Bybit.Api.Sbe;

/// <summary>
/// SBE self-match prevention type.
/// </summary>
public enum BybitSbeSelfMatchPrevention : byte
{
    /// <summary>
    /// Unknown self-match prevention.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Cancel taker.
    /// </summary>
    CancelTaker = 1,

    /// <summary>
    /// Cancel maker.
    /// </summary>
    CancelMaker = 2,

    /// <summary>
    /// Cancel both.
    /// </summary>
    CancelBoth = 3,

    /// <summary>
    /// Non-representable self-match prevention.
    /// </summary>
    NonRepresentable = 254,
}
