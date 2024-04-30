namespace Bybit.Api.Models.User;

/// <summary>
/// Bybit API Key
/// </summary>
public class BybitApiKey
{
    /// <summary>
    /// Unique id. Internal used
    /// </summary>
    public long ID { get; set; }

    /// <summary>
    /// The remark
    /// </summary>
    [JsonProperty("note")]
    public string Label { get; set; }

    /// <summary>
    /// Api key
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// The secret paired with api key.
    /// The secret can't be queried by GET api. Please keep it properly
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// 0：Read and Write. 1：Read only
    /// </summary>
    [JsonConverter(typeof(BooleanConverter))]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// The types of permission
    /// </summary>
    public BybitApiKeyPermissions Permissions { get; set; }

    /// <summary>
    /// IP Addresses
    /// </summary>
    [JsonProperty("ips")]
    public List<string> IpAddresses { get; set; } = [];
}