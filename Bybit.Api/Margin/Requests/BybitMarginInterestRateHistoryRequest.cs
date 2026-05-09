namespace Bybit.Api.Margin;

/// <summary>
/// Get historical spot margin interest rate request.
/// </summary>
public record BybitMarginInterestRateHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarginInterestRateHistoryRequest"/> record.
    /// </summary>
    /// <param name="currency">Coin name.</param>
    public BybitMarginInterestRateHistoryRequest(string currency)
    {
        Currency = currency;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// VIP level.
    /// </summary>
    public string? VipLevel { get; set; }

    /// <summary>
    /// Start timestamp in milliseconds.
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// End timestamp in milliseconds.
    /// </summary>
    public long? EndTime { get; set; }
}
