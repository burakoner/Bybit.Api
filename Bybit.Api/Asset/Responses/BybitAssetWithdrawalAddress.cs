namespace Bybit.Api.Asset;

/// <summary>
/// Bybit withdrawal address book entry.
/// </summary>
public record BybitAssetWithdrawalAddress
{
    /// <summary>
    /// Coin.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Chain name.
    /// </summary>
    public string Chain { get; set; } = string.Empty;

    /// <summary>
    /// Address.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Address tag.
    /// </summary>
    public string Tag { get; set; } = string.Empty;

    /// <summary>
    /// Address remark.
    /// </summary>
    public string Remark { get; set; } = string.Empty;

    /// <summary>
    /// Address status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Address type.
    /// </summary>
    public int AddressType { get; set; }

    /// <summary>
    /// Whether the address has been verified.
    /// </summary>
    public int Verified { get; set; }

    /// <summary>
    /// Address create timestamp in seconds.
    /// </summary>
    [JsonProperty("createAt")]
    public long CreatedTimestamp { get; set; }

    [JsonProperty("createdAt")]
    private long? CreatedTimestampAlias { set { if (value.HasValue) CreatedTimestamp = value.Value; } }

    /// <summary>
    /// Address create time.
    /// </summary>
    [JsonIgnore]
    public DateTime CreatedTime => DateTimeOffset.FromUnixTimeSeconds(CreatedTimestamp).UtcDateTime;
}
