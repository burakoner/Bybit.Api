namespace Bybit.Api.Models;

internal class BybitListResponse<T>
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<T> Payload { get; set; }

    [JsonProperty("configList", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> ConfigList { set => Payload = value; get => Payload; }

    [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> List { set => Payload = value; get => Payload; }

    [JsonProperty("orderBody", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> OrderBody { set => Payload = value; get => Payload; }

    [JsonProperty("rows", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> Rows { set => Payload = value; get => Payload; }

    [JsonProperty("subMembers", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> SubMembers { set => Payload = value; get => Payload; }

    [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected List<T> Result { set => Payload = value; get => Payload; }

    [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory? Category { get; set; }

    [JsonProperty("nextPageCursor", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NextPageCursor { get; set; }
}

internal class BybitUpdateResponse<T>
{
    [JsonProperty("updatedTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("list")]
    public List<T> Payload { get; set; }
}