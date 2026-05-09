namespace Bybit.Api.Asset;

/// <summary>
/// Convert quote request.
/// </summary>
public record BybitAssetConvertQuoteRequest
{
    public BybitAssetConvertQuoteRequest(string accountType, string fromAsset, string toAsset, string requestAsset, decimal requestQuantity)
    {
        AccountType = accountType;
        FromAsset = fromAsset;
        ToAsset = toAsset;
        RequestAsset = requestAsset;
        RequestQuantity = requestQuantity;
    }

    [JsonProperty("accountType")]
    public string AccountType { get; set; }

    [JsonProperty("fromCoin")]
    public string FromAsset { get; set; }

    [JsonProperty("toCoin")]
    public string ToAsset { get; set; }

    [JsonProperty("requestCoin")]
    public string RequestAsset { get; set; }

    [JsonProperty("requestAmount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal RequestQuantity { get; set; }

    [JsonProperty("fromCoinType", NullValueHandling = NullValueHandling.Ignore)]
    public string? FromAssetType { get; set; }

    [JsonProperty("toCoinType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ToAssetType { get; set; }

    [JsonProperty("paramType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ParameterType { get; set; }

    [JsonProperty("paramValue", NullValueHandling = NullValueHandling.Ignore)]
    public string? ParameterValue { get; set; }

    [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
    public string? RequestId { get; set; }
}
