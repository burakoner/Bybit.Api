namespace Bybit.Api.Stream.Updates;

public class BybitKlineStream
{
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("start")]
    public long OpenTimestamp { get; set; }
    public DateTime OpenTime { get => OpenTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("end")]
    public long CloseTimestamp { get; set; }
    public DateTime CloseTime { get => CloseTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("interval"), JsonConverter(typeof(LabelConverter<BybitKlineInterval>))]
    public BybitKlineInterval Interval { get; set; }

    [JsonProperty("open")]
    public decimal Open { get; set; }

    [JsonProperty("high")]
    public decimal High { get; set; }

    [JsonProperty("low")]
    public decimal Low { get; set; }

    [JsonProperty("close")]
    public decimal Close { get; set; }

    [JsonProperty("volume")]
    public decimal Volume { get; set; }

    [JsonProperty("turnover")]
    public decimal Turnover { get; set; }

    [JsonProperty("confirm")]
    public bool Confirm { get; set; }
}

public class BybitLeveragedTokenKlineStream
{
    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }

    [JsonProperty("start")]
    public long OpenTimestamp { get; set; }
    public DateTime OpenTime { get => OpenTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("end")]
    public long CloseTimestamp { get; set; }
    public DateTime CloseTime { get => CloseTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("interval"), JsonConverter(typeof(LabelConverter<BybitKlineInterval>))]
    public BybitKlineInterval Interval { get; set; }

    [JsonProperty("open")]
    public decimal Open { get; set; }

    [JsonProperty("high")]
    public decimal High { get; set; }

    [JsonProperty("low")]
    public decimal Low { get; set; }

    [JsonProperty("close")]
    public decimal Close { get; set; }

    [JsonProperty("confirm")]
    public bool Confirm { get; set; }
}
