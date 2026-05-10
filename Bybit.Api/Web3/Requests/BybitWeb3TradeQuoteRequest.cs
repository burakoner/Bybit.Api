namespace Bybit.Api.Web3;

/// <summary>
/// Web3 trade quote request.
/// </summary>
public record BybitWeb3TradeQuoteRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3TradeQuoteRequest"/> record.
    /// </summary>
    public BybitWeb3TradeQuoteRequest(BybitWeb3TradeType tradeType, string fromTokenCode, decimal fromTokenAmount, string toTokenCode)
    {
        TradeType = tradeType;
        FromTokenCode = fromTokenCode;
        FromTokenAmount = fromTokenAmount;
        ToTokenCode = toTokenCode;
    }

    /// <summary>
    /// Trade type.
    /// </summary>
    [JsonProperty("tradeType"), JsonConverter(typeof(IntegerEnumConverter))]
    public BybitWeb3TradeType TradeType { get; set; }

    /// <summary>
    /// Source token code.
    /// </summary>
    [JsonProperty("fromTokenCode")]
    public string FromTokenCode { get; set; }

    /// <summary>
    /// Amount to pay.
    /// </summary>
    [JsonProperty("fromTokenAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal FromTokenAmount { get; set; }

    /// <summary>
    /// Target token code.
    /// </summary>
    [JsonProperty("toTokenCode")]
    public string ToTokenCode { get; set; }

    /// <summary>
    /// Quote mode.
    /// </summary>
    [JsonProperty("quoteMode", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerEnumConverter))]
    public BybitWeb3QuoteMode? QuoteMode { get; set; }
}
