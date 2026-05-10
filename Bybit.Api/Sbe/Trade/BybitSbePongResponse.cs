namespace Bybit.Api.Sbe;

/// <summary>
/// SBE pong response.
/// </summary>
public record BybitSbePongResponse
{
    /// <summary>
    /// SBE message header.
    /// </summary>
    public BybitSbeMessageHeader Header { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// Echoed client timestamp in milliseconds.
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// Server pong timestamp in milliseconds.
    /// </summary>
    public long PongTime { get; set; }
}
