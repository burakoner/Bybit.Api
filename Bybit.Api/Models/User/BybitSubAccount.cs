namespace Bybit.Api.Models.User;

public class BybitSubAccount
{
    [JsonProperty("uid")]
    public long UID { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("memberType"), JsonConverter(typeof(LabelConverter<BybitSubAccountType>))]
    public BybitSubAccountType Type { get; set; }

    [JsonProperty("status"), JsonConverter(typeof(LabelConverter<BybitSubAccountStatus>))]
    public BybitSubAccountStatus Status { get; set; }

    [JsonProperty("remark")]
    public string Note { get; set; }
}
