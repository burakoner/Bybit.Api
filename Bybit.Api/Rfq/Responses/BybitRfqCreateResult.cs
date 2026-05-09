namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ creation result.
/// </summary>
public record BybitRfqCreateResult
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Custom inquiry ID.
    /// </summary>
    public string RfqLinkId { get; set; } = string.Empty;

    /// <summary>
    /// RFQ status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }

    /// <summary>
    /// Expiration timestamp in milliseconds.
    /// </summary>
    public long ExpiresAt { get; set; }

    /// <summary>
    /// Expiration time.
    /// </summary>
    [JsonIgnore]
    public DateTime ExpirationTime { get => ExpiresAt.ConvertFromMilliseconds(); }

    /// <summary>
    /// Inquiring party desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;
}
