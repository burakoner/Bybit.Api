﻿namespace Bybit.Api.Models.Trade;

public class BybitBatchPlaceOrderResponse
{
    [JsonProperty("category"), JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("orderId")]
    public string OrderId { get; set; }
    
    [JsonProperty("orderLinkId")]
    public string OrderLinkId { get; set; }

    [JsonProperty("createAt"), JsonConverter(typeof(DateTimeConverter))]
    public long CreateAtTimestamp { get; set; }
    public DateTime CreateAtTime { get => CreateAtTimestamp.FromUnixTimeMilliSeconds(); }
}