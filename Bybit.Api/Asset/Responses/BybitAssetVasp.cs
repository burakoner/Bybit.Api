namespace Bybit.Api.Asset;

/// <summary>
/// Bybit VASP entity.
/// </summary>
public record BybitAssetVasp
{
    /// <summary>
    /// Receiver platform id.
    /// </summary>
    public string VaspEntityId { get; set; } = string.Empty;

    /// <summary>
    /// Receiver platform name.
    /// </summary>
    public string VaspName { get; set; } = string.Empty;
}
