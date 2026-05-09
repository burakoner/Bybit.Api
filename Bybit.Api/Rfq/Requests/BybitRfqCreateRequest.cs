namespace Bybit.Api.Rfq;

/// <summary>
/// Create RFQ request.
/// </summary>
public record BybitRfqCreateRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="counterparties">Counterparty desk codes.</param>
    /// <param name="legs">Combination transaction legs.</param>
    public BybitRfqCreateRequest(IEnumerable<string> counterparties, IEnumerable<BybitRfqLegRequest> legs)
    {
        Counterparties = [.. counterparties];
        Legs = [.. legs];
    }

    /// <summary>
    /// Counterparty desk codes.
    /// </summary>
    [JsonProperty("counterparties")]
    public List<string> Counterparties { get; set; }

    /// <summary>
    /// Custom RFQ ID.
    /// </summary>
    [JsonProperty("rfqLinkId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RfqLinkId { get; set; }

    /// <summary>
    /// Whether the inquiry is anonymous.
    /// </summary>
    [JsonProperty("anonymous", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Anonymous { get; set; }

    /// <summary>
    /// Strategy type.
    /// </summary>
    [JsonProperty("strategyType", NullValueHandling = NullValueHandling.Ignore)]
    public string? StrategyType { get; set; }

    /// <summary>
    /// Combination transaction legs.
    /// </summary>
    [JsonProperty("list")]
    public List<BybitRfqLegRequest> Legs { get; set; }
}
