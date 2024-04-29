namespace Bybit.Api.Models.Account;

public class BybitSubUserIds
{
    [JsonProperty("subMemberIds")]
    public List<string> SubUserIds { get; set; } = [];

    [JsonProperty("transferableSubMemberIds")]
    public List<string> TransferableSubUserIds { get; set; } = [];
}
