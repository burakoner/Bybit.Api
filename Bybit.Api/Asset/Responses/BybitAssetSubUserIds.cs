namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Sub User Ids
/// </summary>
public class BybitAssetSubUserIds
{
    /// <summary>
    /// All sub UIDs under the main UID
    /// </summary>
    [JsonProperty("subMemberIds")]
    public List<string> SubUserIds { get; set; } = [];

    /// <summary>
    /// All sub UIDs that have universal transfer enabled
    /// </summary>
    [JsonProperty("transferableSubMemberIds")]
    public List<string> TransferableSubUserIds { get; set; } = [];
}
