namespace Bybit.Api.Models;

public class BybitRestApiListResponse<T>
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IEnumerable<T> Payload { get; set; }

    [JsonProperty("configList", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> configList { set => Payload = value; get => Payload; }

    [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> list { set => Payload = value; get => Payload; }

    [JsonProperty("orderBody", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> orderBody { set => Payload = value; get => Payload; }

    [JsonProperty("rows", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> rows { set => Payload = value; get => Payload; }

    [JsonProperty("subMembers", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> subMembers { set => Payload = value; get => Payload; }
}

internal class BybitRestApiResultResponse<T>
{
    [JsonProperty("result")]
    public IEnumerable<T> Payload { get; set; }
}

internal class BybitRestApiCategoryResponse<T>
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    [JsonProperty("list")]
    public IEnumerable<T> Payload { get; set; }
}

internal class BybitRestApiUpdateResponse<T>
{
    [JsonProperty("updatedTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("list")]
    public IEnumerable<T> Payload { get; set; }
}

public class BybitRestApiCursorResponse<T> : BybitRestApiListResponse<T>
{
    [JsonProperty("nextPageCursor")]
    public string NextPageCursor { get; set; }
}