namespace Bybit.Api.CryptoLoan;

/// <summary>
/// Get fixed crypto loan market request.
/// </summary>
public record BybitCryptoLoanFixedMarketRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitCryptoLoanFixedMarketRequest"/> record.
    /// </summary>
    /// <param name="orderCurrency">Coin name.</param>
    /// <param name="orderBy">Sort field.</param>
    public BybitCryptoLoanFixedMarketRequest(string orderCurrency, BybitFixedBorrowOrderBy orderBy)
    {
        OrderCurrency = orderCurrency;
        OrderBy = orderBy;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("orderCurrency")]
    public string OrderCurrency { get; set; }

    /// <summary>
    /// Sort field.
    /// </summary>
    [JsonProperty("orderBy")]
    public BybitFixedBorrowOrderBy OrderBy { get; set; }

    /// <summary>
    /// Fixed term in days.
    /// </summary>
    [JsonProperty("term", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(IntegerToStringConverter))]
    public int? Term { get; set; }

    /// <summary>
    /// Sort direction.
    /// </summary>
    [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
    public BybitSortDirection? Sort { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
    public int? Limit { get; set; }
}
