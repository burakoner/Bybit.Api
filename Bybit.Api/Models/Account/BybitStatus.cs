namespace Bybit.Api.Models.Account;

/// <summary>
/// Bybit Process Status
/// </summary>
public class BybitStatus
{
    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("status"), JsonConverter(typeof(BooleanConverter))]
    public bool Success { get; set; }
}
