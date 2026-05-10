namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Institutional loan UID association result.
/// </summary>
public record BybitLoanUidAssociation
{
    /// <summary>
    /// UID.
    /// </summary>
    public string Uid { get; set; } = string.Empty;

    /// <summary>
    /// Operation.
    /// </summary>
    [JsonProperty("operate")]
    public BybitLoanUidOperation Operation { get; set; }
}
