namespace Bybit.Api.User;

/// <summary>
/// Sign commodity agreement request.
/// </summary>
public record BybitUserSignAgreementRequest
{
    /// <summary>
    /// Create a new instance.
    /// </summary>
    /// <param name="agree">Agreement flag. Must be true.</param>
    public BybitUserSignAgreementRequest(bool agree)
    {
        Agree = agree;
    }

    /// <summary>
    /// Deprecated category. Use CategoryV2 for new values.
    /// </summary>
    [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
    public int? Category { get; set; }

    /// <summary>
    /// Agreement category.
    /// </summary>
    [JsonProperty("categoryV2", NullValueHandling = NullValueHandling.Ignore)]
    public int? CategoryV2 { get; set; }

    /// <summary>
    /// Agreement flag.
    /// </summary>
    [JsonProperty("agree")]
    public bool Agree { get; set; }
}
