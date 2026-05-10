namespace Bybit.Api.Sbe;

/// <summary>
/// SBE single order response.
/// </summary>
public record BybitSbeOrderResponse
{
    /// <summary>
    /// SBE message header.
    /// </summary>
    public BybitSbeMessageHeader Header { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// API response header.
    /// </summary>
    public BybitSbeApiResponseHeader ResponseHeader { get; set; } = new();

    /// <summary>
    /// Return code.
    /// </summary>
    public int ReturnCode { get; set; }

    /// <summary>
    /// Order identifiers.
    /// </summary>
    public BybitSbeOrderIdentifiers Result { get; set; } = new();

    /// <summary>
    /// Return message.
    /// </summary>
    public string ReturnMessage { get; set; } = string.Empty;
}
