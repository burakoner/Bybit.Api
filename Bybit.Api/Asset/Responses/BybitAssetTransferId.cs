namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Transfer Id
/// </summary>
public class BybitAssetTransferId
{
    /// <summary>
    /// Transfer Id
    /// </summary>
    [JsonProperty("transferId")]
    public string TransferId { get; set; } = string.Empty;

    /// <summary>
    /// Transfer status
    /// </summary>
    [JsonProperty("status")]
    public BybitTransferStatus Status { get; set; }
}
