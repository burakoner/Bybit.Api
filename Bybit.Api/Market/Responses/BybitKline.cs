namespace Bybit.Api.Market;

/// <summary>
/// Bybit Kline
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public class BybitKline
{
    /// <summary>
    /// Open time
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Close price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }

    /// <summary>
    /// Volume
    /// </summary>
    [ArrayProperty(5)]
    public decimal Volume { get; set; }

    /// <summary>
    /// Turnover
    /// </summary>
    [ArrayProperty(6)]
    public decimal Turnover { get; set; }
}

/// <summary>
/// Bybit Mark Price Kline
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public class BybitMarkPriceKline
{
    /// <summary>
    /// Open time
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Close Price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}

/// <summary>
/// Bybit Index Price Kline
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public class BybitIndexPriceKline
{
    /// <summary>
    /// Open time
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Close Price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}

/// <summary>
/// Bybit Premium Index Price Kline
/// </summary>
[JsonConverter(typeof(ArrayConverter))]
public class BybitPremiumIndexPriceKline
{
    /// <summary>
    /// Open time
    /// </summary>
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    /// <summary>
    /// Open price
    /// </summary>
    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    /// <summary>
    /// High price
    /// </summary>
    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    /// <summary>
    /// Low price
    /// </summary>
    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    /// <summary>
    /// Close price
    /// </summary>
    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}