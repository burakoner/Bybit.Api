namespace Bybit.Api.Asset;

/// <summary>
/// Bybit Withdrawal Id
/// </summary>
public record BybitAssetWithdrawalId
{
    /// <summary>
    /// Withdrawal Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Numeric withdrawal ID when the value is numeric.
    /// </summary>
    [JsonIgnore]
    public long? NumericId
    {
        get
        {
            if (long.TryParse(Id, NumberStyles.Integer, CultureInfo.InvariantCulture, out var value))
                return value;

            return null;
        }
    }
}
