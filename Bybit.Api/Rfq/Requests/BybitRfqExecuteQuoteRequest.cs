namespace Bybit.Api.Rfq;

/// <summary>
/// Execute quote request.
/// </summary>
public record BybitRfqExecuteQuoteRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="rfqId">Inquiry ID.</param>
    /// <param name="quoteId">Quote ID.</param>
    /// <param name="quoteSide">Quote side to execute.</param>
    public BybitRfqExecuteQuoteRequest(string rfqId, string quoteId, BybitOrderSide quoteSide)
    {
        RfqId = rfqId;
        QuoteId = quoteId;
        QuoteSide = quoteSide;
    }

    /// <summary>
    /// Inquiry ID.
    /// </summary>
    [JsonProperty("rfqId")]
    public string RfqId { get; set; }

    /// <summary>
    /// Quote ID.
    /// </summary>
    [JsonProperty("quoteId")]
    public string QuoteId { get; set; }

    /// <summary>
    /// Quote side to execute.
    /// </summary>
    [JsonProperty("quoteSide")]
    public BybitOrderSide QuoteSide { get; set; }
}
