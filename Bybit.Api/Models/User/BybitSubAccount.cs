namespace Bybit.Api.Models.User;

/// <summary>
/// Bybit Sub Account
/// </summary>
public class BybitSubAccount
{
    /// <summary>
    /// Sub user Id
    /// </summary>
    [JsonProperty("uid")]
    public long UID { get; set; }

    /// <summary>
    /// Username
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; set; }

    /// <summary>
    /// Sub account type
    /// </summary>
    [JsonProperty("memberType"), JsonConverter(typeof(LabelConverter<BybitSubAccountType>))]
    public BybitSubAccountType Type { get; set; }

    /// <summary>
    /// Account mode
    /// </summary>
    [JsonProperty("accountMode"), JsonConverter(typeof(LabelConverter<BybitAccountMode>))]
    public BybitAccountMode Mode { get; set; }

    /// <summary>
    /// Sub account status
    /// </summary>
    [JsonProperty("status"), JsonConverter(typeof(LabelConverter<BybitSubAccountStatus>))]
    public BybitSubAccountStatus Status { get; set; }

    /// <summary>
    /// Remark
    /// </summary>
    [JsonProperty("remark")]
    public string Label { get; set; }
}
