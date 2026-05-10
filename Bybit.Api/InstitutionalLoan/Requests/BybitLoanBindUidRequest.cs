namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Bind or unbind institutional loan UID request.
/// </summary>
public record BybitLoanBindUidRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitLoanBindUidRequest"/> record.
    /// </summary>
    /// <param name="uid">UID.</param>
    /// <param name="operation">Operation.</param>
    public BybitLoanBindUidRequest(string uid, BybitLoanUidOperation operation)
    {
        Uid = uid;
        Operation = operation;
    }

    /// <summary>
    /// UID.
    /// </summary>
    [JsonProperty("uid")]
    public string Uid { get; set; }

    /// <summary>
    /// Operation.
    /// </summary>
    [JsonProperty("operate")]
    public BybitLoanUidOperation Operation { get; set; }
}
