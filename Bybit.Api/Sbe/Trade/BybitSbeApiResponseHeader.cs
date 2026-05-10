namespace Bybit.Api.Sbe;

/// <summary>
/// SBE API response header.
/// </summary>
public record BybitSbeApiResponseHeader
{
    /// <summary>
    /// Client request ID.
    /// </summary>
    public string RequestId { get; set; } = string.Empty;

    /// <summary>
    /// Connection identifier.
    /// </summary>
    public string ConnectionId { get; set; } = string.Empty;

    /// <summary>
    /// Trace ID for diagnostics.
    /// </summary>
    public string TraceId { get; set; } = string.Empty;

    /// <summary>
    /// Server timestamp in milliseconds.
    /// </summary>
    public long TimeNow { get; set; }

    /// <summary>
    /// Message ingress timestamp in milliseconds.
    /// </summary>
    public long InTime { get; set; }

    /// <summary>
    /// Total rate limit.
    /// </summary>
    public long RateLimit { get; set; }

    /// <summary>
    /// Remaining rate limit tokens.
    /// </summary>
    public long RateLimitStatus { get; set; }

    /// <summary>
    /// Rate-limit reset timestamp in milliseconds.
    /// </summary>
    public long RateLimitResetTimestamp { get; set; }
}
