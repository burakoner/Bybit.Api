namespace Bybit.Api.Trade;

/// <summary>
/// Batch error response from Bybit.
/// </summary>
public record BybitTradingBatchError
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
    public string ErrorMessage { get; set; } = string.Empty;
}