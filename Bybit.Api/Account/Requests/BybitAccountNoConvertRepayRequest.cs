namespace Bybit.Api.Account;

/// <summary>
/// Bybit account manual repay without asset conversion request.
/// </summary>
public record BybitAccountNoConvertRepayRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountNoConvertRepayRequest"/> record.
    /// </summary>
    /// <param name="asset">Coin name.</param>
    public BybitAccountNoConvertRepayRequest(string asset)
    {
        Asset = asset;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Asset { get; set; }

    /// <summary>
    /// Repay amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Repayment type.
    /// </summary>
    public BybitAccountRepaymentType? RepaymentType { get; set; }
}
