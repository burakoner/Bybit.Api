namespace Bybit.Api.Enums;

/// <summary>
/// Bybit convert status.
/// </summary>
public enum BybitConvertStatus
{
    /// <summary>
    /// Initial state.
    /// </summary>
    [Map("init")]
    Initial = 0,

    /// <summary>
    /// Processing.
    /// </summary>
    [Map("processing")]
    Processing = 1,

    /// <summary>
    /// Successful.
    /// </summary>
    [Map("success")]
    Success = 2,

    /// <summary>
    /// Failed.
    /// </summary>
    [Map("failure")]
    Failure = 3,
}
