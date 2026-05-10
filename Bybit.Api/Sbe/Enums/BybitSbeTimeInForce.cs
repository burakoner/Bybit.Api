namespace Bybit.Api.Sbe;

/// <summary>
/// SBE time in force.
/// </summary>
public enum BybitSbeTimeInForce : byte
{
    /// <summary>
    /// Unknown time in force.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Good till cancel.
    /// </summary>
    GoodTillCancel = 1,

    /// <summary>
    /// Post only.
    /// </summary>
    PostOnly = 2,

    /// <summary>
    /// Immediate or cancel.
    /// </summary>
    ImmediateOrCancel = 3,

    /// <summary>
    /// Fill or kill.
    /// </summary>
    FillOrKill = 4,

    /// <summary>
    /// RPI.
    /// </summary>
    Rpi = 5,

    /// <summary>
    /// Non-representable time in force.
    /// </summary>
    NonRepresentable = 254,
}
