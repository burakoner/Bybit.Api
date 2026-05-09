namespace Bybit.Api.Market;

/// <summary>
/// Request for market kline endpoints.
/// </summary>
public record BybitMarketKlineRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketKlineRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="interval">Kline interval</param>
    public BybitMarketKlineRequest(BybitCategory category, string symbol, BybitInterval interval)
    {
        Category = category;
        Symbol = symbol;
        Interval = interval;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Kline interval.
    /// </summary>
    public BybitInterval Interval { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? Start { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? End { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 200;
}

/// <summary>
/// Request for market instrument info endpoints.
/// </summary>
public record BybitMarketInstrumentsRequest
{
    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Symbol status filter.
    /// </summary>
    public BybitInstrumentStatus? Status { get; set; }

    /// <summary>
    /// The region to which the trading pair belongs.
    /// </summary>
    public BybitInstrumentType? SymbolType { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 500;

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}

/// <summary>
/// Request for recent public trades.
/// </summary>
public record BybitMarketTradingHistoryRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketTradingHistoryRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketTradingHistoryRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Base coin. Applies to options only.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Option type. Applies to options only.
    /// </summary>
    public BybitOptionType? OptionType { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }
}

/// <summary>
/// Request for open interest.
/// </summary>
public record BybitMarketOpenInterestRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketOpenInterestRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Interval time</param>
    public BybitMarketOpenInterestRequest(BybitCategory category, string symbol, BybitRecordPeriod period)
    {
        Category = category;
        Symbol = symbol;
        Period = period;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Interval time.
    /// </summary>
    public BybitRecordPeriod Period { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int Limit { get; set; } = 50;

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}

/// <summary>
/// Request for option historical volatility.
/// </summary>
public record BybitMarketVolatilityRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketVolatilityRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketVolatilityRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Quote coin. Supported values are USD and USDT.
    /// </summary>
    public string? QuoteAsset { get; set; }

    /// <summary>
    /// Volatility period.
    /// </summary>
    public BybitOptionPeriod? Period { get; set; }
}

/// <summary>
/// Request for delivery price.
/// </summary>
public record BybitMarketDeliveryPriceRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketDeliveryPriceRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    public BybitMarketDeliveryPriceRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Base coin. Applies to options only.
    /// </summary>
    public string? BaseAsset { get; set; }

    /// <summary>
    /// Settle coin.
    /// </summary>
    public string? SettleAsset { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}

/// <summary>
/// Request for long short ratio.
/// </summary>
public record BybitMarketLongShortRatioRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketLongShortRatioRequest"/> record.
    /// </summary>
    /// <param name="category">Product type</param>
    /// <param name="symbol">Symbol name</param>
    /// <param name="period">Data recording period</param>
    public BybitMarketLongShortRatioRequest(BybitCategory category, string symbol, BybitRecordPeriod period)
    {
        Category = category;
        Symbol = symbol;
        Period = period;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Data recording period.
    /// </summary>
    public BybitRecordPeriod Period { get; set; }

    /// <summary>
    /// The start timestamp (ms).
    /// </summary>
    public long? StartTime { get; set; }

    /// <summary>
    /// The end timestamp (ms).
    /// </summary>
    public long? EndTime { get; set; }

    /// <summary>
    /// Limit for data size per page.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; set; }
}

/// <summary>
/// Request for order price limit.
/// </summary>
public record BybitMarketOrderPriceLimitRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketOrderPriceLimitRequest"/> record.
    /// </summary>
    /// <param name="symbol">Symbol name</param>
    public BybitMarketOrderPriceLimitRequest(string symbol)
    {
        Symbol = symbol;
    }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Product type. Defaults to linear on Bybit when not provided.
    /// </summary>
    public BybitCategory? Category { get; set; }
}

/// <summary>
/// Request for ADL alert.
/// </summary>
public record BybitMarketAdlAlertRequest
{
    /// <summary>
    /// Contract name.
    /// </summary>
    public string? Symbol { get; set; }
}

/// <summary>
/// Request for fee group structure.
/// </summary>
public record BybitMarketFeeGroupInfoRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitMarketFeeGroupInfoRequest"/> record.
    /// </summary>
    /// <param name="productType">Product type</param>
    public BybitMarketFeeGroupInfoRequest(string productType)
    {
        ProductType = productType;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public string ProductType { get; set; }

    /// <summary>
    /// Group ID.
    /// </summary>
    public string? GroupId { get; set; }
}
