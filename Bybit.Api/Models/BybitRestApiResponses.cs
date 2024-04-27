namespace Bybit.Api.Models;

/// <summary>
/// List Response
/// </summary>
/// <typeparam name="T"></typeparam>
public class BybitListResponse<T>
{
    /// <summary>
    /// Payload
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public IEnumerable<T> Payload { get; set; }

    /// <summary>
    /// Config List
    /// </summary>
    [JsonProperty("configList", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> ConfigList { set => Payload = value; get => Payload; }

    /// <summary>
    /// Data
    /// </summary>
    [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> List { set => Payload = value; get => Payload; }

    /// <summary>
    /// Order Body
    /// </summary>
    [JsonProperty("orderBody", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> OrderBody { set => Payload = value; get => Payload; }

    /// <summary>
    /// Rows
    /// </summary>
    [JsonProperty("rows", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> Rows { set => Payload = value; get => Payload; }

    /// <summary>
    /// Sub Members
    /// </summary>
    [JsonProperty("subMembers", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    protected IEnumerable<T> SubMembers { set => Payload = value; get => Payload; }
}

internal class BybitResultResponse<T>
{
    [JsonProperty("result")]
    public IEnumerable<T> Payload { get; set; }
}

internal class BybitCategoryResponse<T>
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    [JsonProperty("list")]
    public IEnumerable<T> Payload { get; set; }
}

internal class BybitUpdateResponse<T>
{
    [JsonProperty("updatedTime")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("list")]
    public IEnumerable<T> Payload { get; set; }
}

/// <summary>
/// Cursor Response
/// </summary>
/// <typeparam name="T"></typeparam>
public class BybitCursorResponse<T> : BybitListResponse<T>
{
    /// <summary>
    /// Next Page Cursor
    /// </summary>
    [JsonProperty("nextPageCursor")]
    public string NextPageCursor { get; set; }
}