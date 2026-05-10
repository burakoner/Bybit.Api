namespace Bybit.Api.Asset;

/// <summary>
/// Subaccount deposit history request.
/// </summary>
public record BybitAssetSubDepositHistoryRequest : BybitAssetDepositHistoryRequest
{
    /// <summary>
    /// Initializes a new subaccount deposit history request.
    /// </summary>
    /// <param name="subUserId">Sub UID.</param>
    public BybitAssetSubDepositHistoryRequest(long subUserId)
    {
        SubUserId = subUserId;
    }

    /// <summary>
    /// Sub UID.
    /// </summary>
    [JsonProperty("subMemberId")]
    public long SubUserId { get; set; }
}
