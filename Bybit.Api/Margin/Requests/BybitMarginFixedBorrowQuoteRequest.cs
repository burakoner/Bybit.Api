namespace Bybit.Api.Margin;

/// <summary>
/// Get fixed-rate borrow order quote request.
/// </summary>
public record BybitMarginFixedBorrowQuoteRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarginFixedBorrowQuoteRequest"/> record.
    /// </summary>
    /// <param name="orderCurrency">Coin name.</param>
    public BybitMarginFixedBorrowQuoteRequest(string orderCurrency)
    {
        OrderCurrency = orderCurrency;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string OrderCurrency { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    public int? Term { get; set; }

    /// <summary>
    /// Sort field.
    /// </summary>
    public BybitFixedBorrowOrderBy? OrderBy { get; set; }

    /// <summary>
    /// Sort direction.
    /// </summary>
    public BybitSortDirection? Sort { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }
}
