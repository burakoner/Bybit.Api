namespace Bybit.Api.InstitutionalLoan;

/// <summary>
/// Repay institutional loan request.
/// </summary>
public record BybitLoanRepayRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitLoanRepayRequest"/> record.
    /// </summary>
    /// <param name="token">Coin name.</param>
    /// <param name="quantity">Quantity to repay.</param>
    public BybitLoanRepayRequest(string token, decimal quantity)
    {
        Token = token;
        Quantity = quantity;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("token")]
    public string Token { get; set; }

    /// <summary>
    /// Quantity to repay.
    /// </summary>
    [JsonProperty("quantity"), JsonConverter(typeof(DecimalToStringConverter))]
    public decimal Quantity { get; set; }
}
