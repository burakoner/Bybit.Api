﻿namespace Bybit.Api.Helpers.Public;

public class BybitLiquidationStream
{
    [JsonProperty("updateTime")]
    public long UpdateTimestamp { get; set; }
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    [JsonProperty("size")]
    public decimal Size { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }
}
