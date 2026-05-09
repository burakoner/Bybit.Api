namespace Bybit.Api.Asset;

/// <summary>
/// Create internal transfer request.
/// </summary>
public record BybitAssetInternalTransferRequest
{
    public BybitAssetInternalTransferRequest(string asset, decimal quantity, BybitAccountType fromAccount, BybitAccountType toAccount)
    {
        Asset = asset;
        Quantity = quantity;
        FromAccount = fromAccount;
        ToAccount = toAccount;
    }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("amount"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }

    [JsonProperty("fromAccountType")]
    public BybitAccountType FromAccount { get; set; }

    [JsonProperty("toAccountType")]
    public BybitAccountType ToAccount { get; set; }

    [JsonProperty("transferId", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransferId { get; set; }
}
