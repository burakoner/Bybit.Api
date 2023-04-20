namespace Bybit.Api.Models.Wallet;

public class BybitSubUserIds
{
    [JsonProperty("subMemberIds")]
    public IEnumerable<string> SubUserIds { get; set; }

    [JsonProperty("transferableSubMemberIds")]
    public IEnumerable<string> TransferableSubUserüIds { get; set; }
}
