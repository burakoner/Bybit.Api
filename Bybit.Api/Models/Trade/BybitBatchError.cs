namespace Bybit.Api.Models.Trade;

/// <summary>
/// Batch error response from Bybit.
/// </summary>
public class BybitBatchError
{
    /// <summary>
    /// Error code.
    /// </summary>
    [JsonProperty("code")]
    public int ErrorCode { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    [JsonProperty("msg")]
    public string ErrorMessage { get; set; }
}