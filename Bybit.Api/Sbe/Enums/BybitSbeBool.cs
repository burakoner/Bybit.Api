namespace Bybit.Api.Sbe;

/// <summary>
/// SBE boolean value.
/// </summary>
public enum BybitSbeBool : byte
{
    /// <summary>
    /// False.
    /// </summary>
    False = 0,

    /// <summary>
    /// True.
    /// </summary>
    True = 1,

    /// <summary>
    /// Non-representable value.
    /// </summary>
    NonRepresentable = 254,
}
