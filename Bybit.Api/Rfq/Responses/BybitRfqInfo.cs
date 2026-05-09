namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ inquiry information.
/// </summary>
public record BybitRfqInfo
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
    /// Counterparty desk codes.
    /// </summary>
    public List<string> Counterparties { get; set; } = [];

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
    /// Strategy type.
    /// </summary>
    public string StrategyType { get; set; } = string.Empty;

    /// <summary>
    /// RFQ status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }

    /// <summary>
    /// Whether non-LP quotes are accepted.
    /// </summary>
    [JsonProperty("acceptOtherQuoteStatus"), JsonConverter(typeof(BooleanConverter))]
    public bool? AcceptOtherQuote { get; set; }

    /// <summary>
    /// Inquiring party desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;

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
    /// RFQ legs.
    /// </summary>
    public List<BybitRfqLeg> Legs { get; set; } = [];
}

/// <summary>
/// RFQ inquiry leg.
/// </summary>
public record BybitRfqLeg
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
    /// Inquiry direction.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }
}
