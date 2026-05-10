namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Get institutional loan margin coin information request.
/// </summary>
public record BybitLoanMarginCoinRequest
{
    /// <summary>
    /// Product ID.
    /// </summary>
    [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProductId { get; set; }
}
