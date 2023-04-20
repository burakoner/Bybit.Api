namespace Bybit.Api.Models;

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