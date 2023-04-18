namespace Bybit.Api.Models;

public class BybitRestApiResponse<T>
{
    [JsonProperty("result")]
    public T Result { get; set; }

    [JsonProperty("retCode")]
    public int ReturnCode { get; set; }

    [JsonProperty("retMsg")]
    public string ReturnMessage { get; set; }

    [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime Timestamp { get; set; }
}

public class BybitRestApiResponse<TReturn, TExtra>
{
    [JsonProperty("result")]
    public TReturn Result { get; set; }

    [JsonProperty("retCode")]
    public int ReturnCode { get; set; }

    [JsonProperty("retMsg")]
    public string ReturnMessage { get; set; }

    [JsonProperty("retExtInfo")]
    public TExtra ReturnExtraInfo { get; set; }

    [JsonProperty("time"), JsonConverter(typeof(DateTimeConverter))]
    public DateTime Timestamp { get; set; }
}