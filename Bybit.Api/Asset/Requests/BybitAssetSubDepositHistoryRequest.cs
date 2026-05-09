namespace Bybit.Api.Asset;

/// <summary>
/// Subaccount deposit history request.
/// </summary>
public record BybitAssetSubDepositHistoryRequest : BybitAssetDepositHistoryRequest
{
    public BybitAssetSubDepositHistoryRequest(long subUserId)
    {
        SubUserId = subUserId;
    }

    [JsonProperty("subMemberId")]
    public long SubUserId { get; set; }
}
