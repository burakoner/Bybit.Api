namespace Bybit.Api.Models.Market;

public class BybitKlineContainer<T>
{
    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    public IEnumerable<T> List { get; set; }
}

[JsonConverter(typeof(ArrayConverter))]
public class BybitPriceKline
{
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }

    [ArrayProperty(5)]
    public decimal Volume { get; set; }

    [ArrayProperty(6)]
    public decimal Turnover { get; set; }
}

[JsonConverter(typeof(ArrayConverter))]
public class BybitMarkPriceKline
{
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}

[JsonConverter(typeof(ArrayConverter))]
public class BybitIndexPriceKline
{
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}

[JsonConverter(typeof(ArrayConverter))]
public class BybitPremiumIndexPriceKline
{
    [ArrayProperty(0), JsonConverter(typeof(DateTimeConverter))]
    public DateTime OpenTime { get; set; }

    [ArrayProperty(1)]
    public decimal OpenPrice { get; set; }

    [ArrayProperty(2)]
    public decimal HighPrice { get; set; }

    [ArrayProperty(3)]
    public decimal LowPrice { get; set; }

    [ArrayProperty(4)]
    public decimal ClosePrice { get; set; }
}