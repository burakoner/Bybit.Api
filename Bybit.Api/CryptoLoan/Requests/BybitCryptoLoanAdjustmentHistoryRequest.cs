namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get crypto loan collateral adjustment history request.
/// </summary>
public record BybitCryptoLoanAdjustmentHistoryRequest
{
    /// <summary>
    /// Collateral adjustment transaction ID.
    /// </summary>
    [JsonProperty("adjustId", NullValueHandling = NullValueHandling.Ignore)]
    public string? AdjustId { get; set; }

    /// <summary>
    /// Collateral coin name.
    /// </summary>
    [JsonProperty("collateralCurrency", NullValueHandling = NullValueHandling.Ignore)]
    public string? CollateralCurrency { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor.
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }
}
