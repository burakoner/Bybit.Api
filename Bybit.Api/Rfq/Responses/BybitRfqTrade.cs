namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ trade.
/// </summary>
public record BybitRfqTrade
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
    /// Executed quote side.
    /// </summary>
    public BybitOrderSide QuoteSide { get; set; }

    /// <summary>
    /// Strategy type.
    /// </summary>
    public string StrategyType { get; set; } = string.Empty;

    /// <summary>
    /// Trade status.
    /// </summary>
    public BybitRfqStatus Status { get; set; }

    /// <summary>
    /// Inquiring party desk code.
    /// </summary>
    [JsonProperty("rfqDeskCode")]
    public string RfqDeskCode { get; set; } = string.Empty;

    /// <summary>
    /// Quoting party desk code.
    /// </summary>
    public string QuoteDeskCode { get; set; } = string.Empty;

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
    /// Trade legs.
    /// </summary>
    public List<BybitRfqTradeLeg> Legs { get; set; } = [];
}

/// <summary>
/// RFQ trade leg.
/// </summary>
public record BybitRfqTradeLeg
{
    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Bybit order ID.
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Instrument symbol.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Execution direction.
    /// </summary>
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Execution price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Executed quantity.
    /// </summary>
    [JsonProperty("qty")]
    public decimal Quantity { get; set; }

    /// <summary>
    /// Mark or index price at execution time.
    /// </summary>
    public decimal? MarkPrice { get; set; }

    /// <summary>
    /// Execution fee.
    /// </summary>
    public decimal? ExecFee { get; set; }

    /// <summary>
    /// Execution ID.
    /// </summary>
    public string ExecId { get; set; } = string.Empty;

    /// <summary>
    /// Leg result code. Zero means success.
    /// </summary>
    public int ResultCode { get; set; }

    /// <summary>
    /// Leg result message.
    /// </summary>
    public string ResultMessage { get; set; } = string.Empty;

    /// <summary>
    /// Rejecting party.
    /// </summary>
    public string RejectParty { get; set; } = string.Empty;
}
