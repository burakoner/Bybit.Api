namespace Bybit.Api.Common;

internal record BybitListResponse<T>
{
    public List<T> Payload { get; set; } = [];

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
    public BybitCategory? Category { get; set; }

    [JsonProperty("nextPageCursor", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string NextPageCursor { get; set; } = string.Empty;

    [JsonProperty("updatedTime", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public long? UpdateTimestamp { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? UpdateTime { get => UpdateTimestamp?.ConvertFromMilliseconds(); }
}

/// <summary>
/// BybitRestApiResponse
/// </summary>
public record BybitRestApiResponse
{
    /// <summary>
    /// Return code
    /// </summary>
    [JsonProperty("retCode")]
    public int ReturnCode { get; set; }

    /// <summary>
    /// Return message
    /// </summary>
    [JsonProperty("retMsg")]
    public string ReturnMessage { get; set; } = string.Empty;

    /// <summary>
    /// Timestamp
    /// </summary>
    [JsonProperty("time")]
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// BybitRestApiResponse
/// </summary>
/// <typeparam name="T"></typeparam>
public record BybitRestApiResponse<T> : BybitRestApiResponse
{
    /// <summary>
    /// Result
    /// </summary>
    [JsonProperty("result")]
    public T Result { get; set; } = default!;
}

/// <summary>
/// BybitRestApiResponse
/// </summary>
/// <typeparam name="TResult"></typeparam>
/// <typeparam name="TExtra"></typeparam>
public record BybitRestApiResponse<TResult, TExtra> : BybitRestApiResponse<TResult>
{
    /// <summary>
    /// Return extra info
    /// </summary>
    [JsonProperty("retExtInfo")]
    public TExtra ReturnExtraInfo { get; set; } = default!;
}