﻿namespace Bybit.Api.Models.Trade;

/// <summary>
/// Bybit move position response
/// </summary>
public class BybitMovePositionResponse
{
    /// <summary>
    /// Block trade ID
    /// </summary>
    [JsonProperty("blockTradeId")]
    public string BlockTradeId { get; set; }

    /// <summary>
    /// Order status. Processing, Filled, Rejected
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitMovePositionStatus>))]
    public BybitMovePositionStatus Status { get; set; }

    /// <summary>
    /// "" means initial validation is passed, please check the order status via Get Move Position History
    /// Taker, Maker when status=Rejected
    /// bybit means error is occurred on the Bybit side
    /// </summary>
    public string RejectParty { get; set; }
}