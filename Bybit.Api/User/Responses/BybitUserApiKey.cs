namespace Bybit.Api.User;

/// <summary>
/// Bybit API Key
/// </summary>
public record BybitUserApiKey
{
    /// <summary>
    /// Unique id. Internal used
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Numeric unique ID when the value is numeric.
    /// </summary>
    [Obsolete("Use Id instead.")]
    [JsonIgnore]
    public long ID
    {
        get
        {
            if (long.TryParse(Id, NumberStyles.Integer, CultureInfo.InvariantCulture, out var value))
                return value;

            return 0L;
        }
        set => Id = value.ToString(CultureInfo.InvariantCulture);
    }

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
    /// The secret paired with api key.
    /// The secret can't be queried by GET api. Please keep it properly
    /// </summary>
    public string Secret { get; set; } = string.Empty;

    /// <summary>
    /// 0：Read and Write. 1：Read only
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// The types of permission
    /// </summary>
    public BybitUserApiKeyPermissions Permissions { get; set; } = default!;

    /// <summary>
    /// IP Addresses
    /// </summary>
    [JsonProperty("ips")]
    public List<string> IpAddresses { get; set; } = [];

    /// <summary>
    /// API key status.
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// Expiry day of the API key.
    /// </summary>
    public DateTime? ExpiredAt { get; set; }

    /// <summary>
    /// Create day of the API key.
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// API key type.
    /// </summary>
    public BybitApiKeyType? Type { get; set; }

    /// <summary>
    /// Remaining valid days of the API key.
    /// </summary>
    public int? DeadlineDay { get; set; }

    /// <summary>
    /// API key type flag, for example hmac.
    /// </summary>
    public string Flag { get; set; } = string.Empty;
}
