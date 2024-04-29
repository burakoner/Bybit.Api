namespace Bybit.Api.Models.User;

public class BybitApiKeyInformation
{
    public string ID { get; set; }

    [JsonProperty("note")]
    public string Label { get; set; }

    public string ApiKey { get; set; }
    public string Secret { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool Readonly { get; set; }

    public BybitApiKeyPermissions Permissions { get; set; }
    public List<string> Ips { get; set; } = [];

    [JsonConverter(typeof(LabelConverter<BybitApiKeyType>))]
    public BybitApiKeyType Type { get; set; }

    [JsonProperty("deadlineDay")]
    public int DeadlineDays { get; set; }

    [JsonProperty("expiredAt")]
    public long? ExpireTimestamp { get; set; }
    public DateTime? ExpireTime { get => ExpireTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("createdAt")]
    public long? CreateTimestamp { get; set; }
    public DateTime? CreateTime { get => CreateTimestamp?.ConvertFromMilliseconds(); }

    [JsonProperty("unified"), JsonConverter(typeof(BooleanConverter))]
    public bool UnifiedMArginAccount { get; set; }

    [JsonProperty("uta"), JsonConverter(typeof(BooleanConverter))]
    public bool UnifiedTradeAccount { get; set; }

    public long UserId { get; set; }

    public long? InviterId { get; set; }

    public string VipLevel { get; set; }
    [JsonProperty("mktMakerLevel")]
    public string MarketMakerLevel { get; set; }
    public long AffiliateId { get; set; }
    public string RsaPublicKey { get; set; }
    public bool IsMaster { get; set; }
}