namespace Bybit.Api.Sbe;

/// <summary>
/// SBE authentication response.
/// </summary>
public record BybitSbeAuthResponse
{
    /// <summary>
    /// SBE message header.
    /// </summary>
    public BybitSbeMessageHeader Header { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// Client request ID.
    /// </summary>
    public string RequestId { get; set; } = string.Empty;

    /// <summary>
    /// Return code.
    /// </summary>
    public int ReturnCode { get; set; }

    /// <summary>
    /// Connection identifier.
    /// </summary>
    public string ConnectionId { get; set; } = string.Empty;

    /// <summary>
    /// Return message.
    /// </summary>
    public string ReturnMessage { get; set; } = string.Empty;
}
