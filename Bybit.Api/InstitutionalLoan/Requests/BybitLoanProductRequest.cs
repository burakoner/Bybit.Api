namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Get institutional loan product information request.
/// </summary>
public record BybitLoanProductRequest
{
    /// <summary>
    /// Product ID.
    /// </summary>
    [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProductId { get; set; }
}
