namespace Bybit.Api.Sbe;

/// <summary>
/// SBE order identifiers.
/// </summary>
public record BybitSbeOrderIdentifiers
{
    /// <summary>
    /// Exchange-assigned order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Client order ID.
    /// </summary>
    public string OrderLinkId { get; set; } = string.Empty;
}
