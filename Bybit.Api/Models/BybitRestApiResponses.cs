namespace Bybit.Api.Models;

public class BybitRestApiListResponse<T>
{
    [JsonProperty("list")]
    public IEnumerable<T> List { get; set; }
}

public class BybitRestApiCategoryResponse<T> : BybitRestApiListResponse<T>
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }
}

public class BybitRestApiCursorResponse<T> : BybitRestApiCategoryResponse<T>
{
    [JsonProperty("nextPageCursor")]
    public string NextPageCursor { get; set; }
}

public class BybitRestApiUpdateResponse<T> : BybitRestApiListResponse<T>
{
    [JsonProperty("updatedTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}