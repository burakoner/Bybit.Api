namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ quote information.
/// </summary>
public record BybitRfqQuote
{
    /// <summary>
    /// Inquiry ID.
    /// </summary>
    public string RfqId { get; set; } = string.Empty;

    /// <summary>
    /// Custom RFQ ID.
    /// </summary>
    public string RfqLinkId { get; set; } = string.Empty;

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
    /// Inquiring party desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;

    /// <summary>
    /// Quote status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }

    /// <summary>
    /// Execute quote side. This can be empty until a quote is executed.
    /// </summary>
    public string ExecQuoteSide { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp in milliseconds.
    /// </summary>
    public long CreatedAt { get; set; }

    /// <summary>
    /// Creation time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime { get => CreatedAt.ConvertFromMilliseconds(); }

    /// <summary>
    /// Update timestamp in milliseconds.
    /// </summary>
    public long UpdatedAt { get; set; }

    /// <summary>
    /// Update time.
    /// </summary>
    [JsonIgnore]
    public DateTime UpdatedTime { get => UpdatedAt.ConvertFromMilliseconds(); }

    /// <summary>
    /// Buy direction quote legs.
    /// </summary>
    public List<BybitRfqQuoteLeg> QuoteBuyList { get; set; } = [];

    /// <summary>
    /// Sell direction quote legs.
    /// </summary>
    public List<BybitRfqQuoteLeg> QuoteSellList { get; set; } = [];
}

/// <summary>
/// RFQ quote leg.
/// </summary>
public record BybitRfqQuoteLeg
{
    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Instrument symbol.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Quote price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }
}
