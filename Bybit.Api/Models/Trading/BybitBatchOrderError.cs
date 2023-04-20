namespace Bybit.Api.Models.Trading;

public class BybitBatchOrderError
{
    [JsonProperty("code")]
    public int ErrorCode { get; set; }

    [JsonProperty("msg")]
    public string ErrorMessage { get; set; }
}