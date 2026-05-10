namespace Bybit.Api.Enums;

/// <summary>
/// Institutional loan UID association operation.
/// </summary>
public enum BybitLoanUidOperation
{
    /// <summary>
    /// Bind UID.
    /// </summary>
    [Map("0")]
    Bind = 0,

    /// <summary>
    /// Unbind UID.
    /// </summary>
    [Map("1")]
    Unbind = 1,
}
