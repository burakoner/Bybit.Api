namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card asset records request.
/// </summary>
public record BybitCardAssetRecordsRequest
{
    /// <summary>
    /// Transaction status code.
    /// </summary>
    [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardAssetRecordStatusCode? StatusCode { get; set; }

    /// <summary>
    /// Number of items per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Page number.
    /// </summary>
    [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page { get; set; }

    /// <summary>
    /// Last 2/4 digits of card number.
    /// </summary>
    [JsonProperty("pan4", NullValueHandling = NullValueHandling.Ignore)]
    public string? Pan4 { get; set; }

    /// <summary>
    /// Start time of transaction in milliseconds.
    /// </summary>
    [JsonProperty("createBeginTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? CreateBeginTime { get; set; }

    /// <summary>
    /// End time of transaction in milliseconds.
    /// </summary>
    [JsonProperty("createEndTime", NullValueHandling = NullValueHandling.Ignore)]
    public long? CreateEndTime { get; set; }

    /// <summary>
    /// Merchant name.
    /// </summary>
    [JsonProperty("merchName", NullValueHandling = NullValueHandling.Ignore)]
    public string? MerchantName { get; set; }

    /// <summary>
    /// Query type.
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public BybitCardAssetRecordQueryType? Type { get; set; }

    /// <summary>
    /// Transaction ID.
    /// </summary>
    [JsonProperty("txnId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionId { get; set; }

    /// <summary>
    /// Card token.
    /// </summary>
    [JsonProperty("cardToken", NullValueHandling = NullValueHandling.Ignore)]
    public string? CardToken { get; set; }

    /// <summary>
    /// Order number.
    /// </summary>
    [JsonProperty("orderNo", NullValueHandling = NullValueHandling.Ignore)]
    public string? OrderNo { get; set; }
}
