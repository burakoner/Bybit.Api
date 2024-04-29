namespace Bybit.Api.Models;

internal class BybitUnifiedResponse<T>
{
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

    [JsonProperty("updatedTime", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long? UpdateTimestamp { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }
}

public class BybitRestApiResponse
{
    [JsonProperty("retCode")]
    public int ReturnCode { get; set; }

    [JsonProperty("retMsg")]
    public string ReturnMessage { get; set; }

    [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime Timestamp { get; set; }
}

public class BybitRestApiResponse<T> : BybitRestApiResponse
{
    [JsonProperty("result")]
    public T Result { get; set; }
}

public class BybitRestApiResponse<TResult, TExtra> : BybitRestApiResponse<TResult>
{
    [JsonProperty("retExtInfo")]
    public TExtra ReturnExtraInfo { get; set; }
}