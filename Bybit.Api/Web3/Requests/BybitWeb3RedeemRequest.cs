namespace Bybit.Api.Web3;

/// <summary>
/// Web3 execute redeem request.
/// </summary>
public record BybitWeb3RedeemRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitWeb3RedeemRequest"/> record.
    /// </summary>
    public BybitWeb3RedeemRequest(string fromTokenCode, decimal fromTokenAmount, string toTokenCode, decimal slippage, string quoteData, decimal gas, BybitWeb3QuoteMode quoteMode, string correctingCode)
    {
        FromTokenCode = fromTokenCode;
        FromTokenAmount = fromTokenAmount;
        ToTokenCode = toTokenCode;
        Slippage = slippage;
        QuoteData = quoteData;
        Gas = gas;
        QuoteMode = quoteMode;
        CorrectingCode = correctingCode;
    }

    /// <summary>
    /// On-chain token code to sell.
    /// </summary>
    [JsonProperty("fromTokenCode")]
    public string FromTokenCode { get; set; }

    /// <summary>
    /// Amount to sell.
    /// </summary>
    [JsonProperty("fromTokenAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal FromTokenAmount { get; set; }

    /// <summary>
    /// Payment token code to receive.
    /// </summary>
    [JsonProperty("toTokenCode")]
    public string ToTokenCode { get; set; }

    /// <summary>
    /// Slippage tolerance.
    /// </summary>
    [JsonProperty("slippage"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Slippage { get; set; }

    /// <summary>
    /// Quote data returned from the quote endpoint.
    /// </summary>
    [JsonProperty("quoteData")]
    public string QuoteData { get; set; }

    /// <summary>
    /// Estimated gas fee returned from the quote endpoint.
    /// </summary>
    [JsonProperty("gas"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Gas { get; set; }

    /// <summary>
    /// Quote mode.
    /// </summary>
    [JsonProperty("quoteMode"), JsonConverter(typeof(IntegerEnumConverter))]
    public BybitWeb3QuoteMode QuoteMode { get; set; }

    /// <summary>
    /// Quote checksum returned from the quote endpoint.
    /// </summary>
    [JsonProperty("correctingCode")]
    public string CorrectingCode { get; set; }

    /// <summary>
    /// Optional tenant identifier.
    /// </summary>
    [JsonProperty("tenant", NullValueHandling = NullValueHandling.Ignore)]
    public string? Tenant { get; set; }
}
