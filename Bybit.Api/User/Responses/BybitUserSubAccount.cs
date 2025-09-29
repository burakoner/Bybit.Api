namespace Bybit.Api.User;

/// <summary>
/// Bybit Sub Account
/// </summary>
public class BybitUserSubAccount
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
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Sub account type
    /// </summary>
    [JsonProperty("memberType")]
    public BybitSubAccountType Type { get; set; }

    /// <summary>
    /// Account mode
    /// </summary>
    [JsonProperty("accountMode")]
    public BybitAccountMode? Mode { get; set; }

    /// <summary>
    /// Sub account status
    /// </summary>
    [JsonProperty("status")]
    public BybitSubAccountStatus Status { get; set; }

    /// <summary>
    /// Remark
    /// </summary>
    [JsonProperty("remark")]
    public string Label { get; set; } = string.Empty;
}
