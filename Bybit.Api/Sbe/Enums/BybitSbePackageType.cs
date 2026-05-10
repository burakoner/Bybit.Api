namespace Bybit.Api.Sbe;

/// <summary>
/// SBE package type.
/// </summary>
public enum BybitSbePackageType : byte
{
    /// <summary>
    /// Snapshot.
    /// </summary>
    Snapshot = 0,

    /// <summary>
    /// Delta.
    /// </summary>
    Delta = 1,
}
