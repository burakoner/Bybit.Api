namespace Bybit.Api.Asset;

/// <summary>
/// Create universal transfer request.
/// </summary>
public record BybitAssetUniversalTransferRequest
{
    public BybitAssetUniversalTransferRequest(string asset, decimal quantity, string fromMemberId, string toMemberId, BybitAccountType fromAccount, BybitAccountType toAccount)
    {
        Asset = asset;
        Quantity = quantity;
        FromMemberId = fromMemberId;
        ToMemberId = toMemberId;
        FromAccount = fromAccount;
        ToAccount = toAccount;
    }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    [JsonProperty("fromMemberId")]
    public string FromMemberId { get; set; }

    [JsonProperty("toMemberId")]
    public string ToMemberId { get; set; }

    [JsonProperty("fromAccountType")]
    public BybitAccountType FromAccount { get; set; }

    [JsonProperty("toAccountType")]
    public BybitAccountType ToAccount { get; set; }

    [JsonProperty("transferId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransferId { get; set; }
}
