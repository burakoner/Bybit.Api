namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ quote result.
/// </summary>
public record BybitRfqQuoteResult
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Quote ID.
    /// </summary>
    public string QuoteId { get; set; } = string.Empty;

    /// <summary>
    /// Custom quote ID.
    /// </summary>
    public string QuoteLinkId { get; set; } = string.Empty;

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
    /// Quoter desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;

    /// <summary>
    /// Quote status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }
}
