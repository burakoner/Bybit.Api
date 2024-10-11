namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Process Status
/// </summary>
public class BybitAssetStatus
{
    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("status"), JsonConverter(typeof(BooleanConverter))]
    public bool Success { get; set; }
}
