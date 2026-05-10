namespace Bybit.Api.Asset;

/// <summary>
/// Convert quote request.
/// </summary>
public record BybitAssetConvertQuoteRequest
{
    /// <summary>
    /// Initializes a new convert quote request.
    /// </summary>
    /// <param name="accountType">Convert wallet type.</param>
    /// <param name="fromAsset">Coin to sell, uppercase only.</param>
    /// <param name="toAsset">Coin to buy, uppercase only.</param>
    /// <param name="requestAsset">Coin used to specify the requested amount.</param>
    /// <param name="requestQuantity">Requested convert amount.</param>
    public BybitAssetConvertQuoteRequest(string accountType, string fromAsset, string toAsset, string requestAsset, decimal requestQuantity)
    {
        AccountType = accountType;
        FromAsset = fromAsset;
        ToAsset = toAsset;
        RequestAsset = requestAsset;
        RequestQuantity = requestQuantity;
    }

    /// <summary>
    /// Convert wallet type.
    /// </summary>
    [JsonProperty("accountType")]
    public string AccountType { get; set; }

    /// <summary>
    /// Coin to sell, uppercase only.
    /// </summary>
    [JsonProperty("fromCoin")]
    public string FromAsset { get; set; }

    /// <summary>
    /// Coin to buy, uppercase only.
    /// </summary>
    [JsonProperty("toCoin")]
    public string ToAsset { get; set; }

    /// <summary>
    /// Coin used to specify the requested amount.
    /// </summary>
    [JsonProperty("requestCoin")]
    public string RequestAsset { get; set; }

    /// <summary>
    /// Requested convert amount.
    /// </summary>
    [JsonProperty("requestAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal RequestQuantity { get; set; }

    /// <summary>
    /// Source coin account type.
    /// </summary>
    [JsonProperty("fromCoinType", NullValueHandling = NullValueHandling.Ignore)]
    public string? FromAssetType { get; set; }

    /// <summary>
    /// Destination coin account type.
    /// </summary>
    [JsonProperty("toCoinType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ToAssetType { get; set; }

    /// <summary>
    /// Additional quote parameter type.
    /// </summary>
    [JsonProperty("paramType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ParameterType { get; set; }

    /// <summary>
    /// Additional quote parameter value.
    /// </summary>
    [JsonProperty("paramValue", NullValueHandling = NullValueHandling.Ignore)]
    public string? ParameterValue { get; set; }

    /// <summary>
    /// Custom request ID for idempotency.
    /// </summary>
    [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RequestId { get; set; }
}
