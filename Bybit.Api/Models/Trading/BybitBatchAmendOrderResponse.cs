﻿namespace Bybit.Api.Models.Trading;

public class BybitBatchAmendOrderResponse
{
    [JsonProperty("orderId")]
    public string OrderId { get; set; }

    [JsonProperty("orderLinkId")]
    public string ClientOrderId { get; set; }
}