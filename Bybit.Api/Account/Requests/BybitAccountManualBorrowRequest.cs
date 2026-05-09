namespace Bybit.Api.Account;

/// <summary>
/// Bybit account manual borrow request.
/// </summary>
public record BybitAccountManualBorrowRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountManualBorrowRequest"/> record.
    /// </summary>
    /// <param name="asset">Coin name.</param>
    /// <param name="amount">Borrow amount.</param>
    public BybitAccountManualBorrowRequest(string asset, decimal amount)
    {
        Asset = asset;
        Amount = amount;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Asset { get; set; }

    /// <summary>
    /// Borrow amount.
    /// </summary>
    public decimal Amount { get; set; }
}
