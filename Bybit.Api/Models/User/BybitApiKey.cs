namespace Bybit.Api.Models.User;

public class BybitApiKey
{
    public long ID { get; set; }

    [JsonProperty("note")]
    public string Label { get; set; }

    public string ApiKey { get; set; }
    public string Secret { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool ReadOnly { get; set; }
    public BybitApiKeyPermissions Permissions { get; set; }
    public List<string> Ips { get; set; } = [];
}