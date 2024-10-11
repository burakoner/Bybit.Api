namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Withdrawal Id
/// </summary>
public class BybitAssetWithdrawalId
{
    /// <summary>
    /// Withdrawal Id
    /// </summary>
    [JsonProperty("id")]
    public long? Id { get; set; }
}
