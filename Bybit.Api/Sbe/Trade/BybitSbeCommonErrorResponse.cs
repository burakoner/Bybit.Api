namespace Bybit.Api.Sbe;

/// <summary>
/// SBE common error response.
/// </summary>
public record BybitSbeCommonErrorResponse
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
    /// Return message.
    /// </summary>
    public string ReturnMessage { get; set; } = string.Empty;
}
