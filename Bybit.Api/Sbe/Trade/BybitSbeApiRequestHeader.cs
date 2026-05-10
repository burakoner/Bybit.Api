namespace Bybit.Api.Sbe;

/// <summary>
/// SBE API request header.
/// </summary>
public record BybitSbeApiRequestHeader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeApiRequestHeader"/> record.
    /// </summary>
    public BybitSbeApiRequestHeader(string? requestId = null, long? timestamp = null, int receiveWindow = 5000, string? referer = null)
    {
        RequestId = requestId ?? string.Empty;
        Timestamp = timestamp ?? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        ReceiveWindow = receiveWindow;
        Referer = referer ?? string.Empty;
    }

    /// <summary>
    /// Client request ID.
    /// </summary>
    public string RequestId { get; set; }

    /// <summary>
    /// Client timestamp in milliseconds.
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// Acceptable time window in milliseconds.
    /// </summary>
    public int ReceiveWindow { get; set; }

    /// <summary>
    /// Broker or source identifier.
    /// </summary>
    public string Referer { get; set; }
}
