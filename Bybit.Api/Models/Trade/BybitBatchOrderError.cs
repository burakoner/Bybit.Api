namespace Bybit.Api.Models.Trade;

public class BybitBatchOrderError
{
    [JsonProperty("code")]
    public int ErrorCode { get; set; }

    [JsonProperty("msg")]
    public string ErrorMessage { get; set; }
}