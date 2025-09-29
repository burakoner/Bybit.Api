namespace Bybit.Api.User;

/// <summary>
/// Bybit API Key
/// </summary>
public record BybitUserApiKey
{
    /// <summary>
    /// Unique id. Internal used
    /// </summary>
    public long ID { get; set; }

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
}