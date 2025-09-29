namespace Bybit.Api.User;

/// <summary>
/// Bybit API Key Information
/// </summary>
public record BybitUserApiKeyInformation
{
    /// <summary>
    /// Unique ID. Internal use
    /// </summary>
    public string ID { get; set; } = string.Empty;

    /// <summary>
    /// The remark
    /// </summary>
    [JsonProperty("note")]
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Api key
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Always ""
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// 0：Read and Write. 1：Read only
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool Readonly { get; set; }

    /// <summary>
    /// The types of permission
    /// </summary>
    public BybitUserApiKeyPermissions Permissions { get; set; } = default!;

    /// <summary>
    /// IP bound
    /// </summary>
    [JsonProperty("ips")]
    public List<string> IpAddresses { get; set; } = [];

    /// <summary>
    /// The type of api key. 1：personal, 2：connected to the third-party app
    /// </summary>
    public BybitApiKeyType Type { get; set; }

    /// <summary>
    /// The remaining valid days of api key. Only for those api key with no IP bound or the password has been changed
    /// </summary>
    [JsonProperty("deadlineDay")]
    public int DeadlineDays { get; set; }

    /// <summary>
    /// The expiry day of the api key. Only for those api key with no IP bound or the password has been changed
    /// </summary>
    [JsonProperty("expiredAt")]
    public DateTime? ExpiredAt { get; set; }

    /// <summary>
    /// The create day of the api key
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Whether the account to which the account upgrade to unified trade account. 0：regular account; 1：unified trade account
    /// </summary>
    [JsonProperty("uta"), JsonConverter(typeof(BooleanConverter))]
    public bool UnifiedTradeAccount { get; set; }

    /// <summary>
    /// User ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Inviter ID (the UID of the account which invited this account to the platform)
    /// </summary>
    public long? InviterId { get; set; }

    /// <summary>
    /// VIP Level
    /// </summary>
    public BybitVipLevel VipLevel { get; set; }

    /// <summary>
    /// Market maker level
    /// </summary>
    [JsonProperty("mktMakerLevel")]
    public string MarketMakerLevel { get; set; } = string.Empty;

    /// <summary>
    /// Affiliate Id. 0 represents that there is no binding relationship.
    /// </summary>
    public long AffiliateId { get; set; }

    /// <summary>
    /// Rsa public key
    /// </summary>
    public string RsaPublicKey { get; set; } = string.Empty;

    /// <summary>
    /// If this api key belongs to master account or not
    /// </summary>
    public bool IsMaster { get; set; }

    /// <summary>
    /// The main account uid. Returns "0" when the endpoint is called by main account
    /// </summary>
    public long ParentUid { get; set; }

    /// <summary>
    /// KycLevel
    /// </summary>
    public string KycLevel { get; set; } = string.Empty;

    /// <summary>
    /// KycRegion
    /// </summary>
    public string KycRegion { get; set; } = string.Empty;
}