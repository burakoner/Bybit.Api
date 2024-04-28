namespace Bybit.Api.Models.Trade;

/// <summary>
/// Bybit move position history
/// </summary>
public class BybitMovePositionHistory
{
    /// <summary>
    /// Block trade ID
    /// </summary>
    [JsonProperty("blockTradeId")]
    public string BlockTradeId { get; set; }

    /// <summary>
    /// Product type. linear, spot, option
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Bybit order ID
    /// </summary>
    public string OrderId { get; set; }

    /// <summary>
    /// User ID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Symbol name
    /// </summary>
    public string Symbol { get; set; }

    /// <summary>
    /// Order side from taker's perspective. Buy, Sell
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// Order price
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Order quantity
    /// </summary>
    [JsonProperty("qty")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// The fee for taker or maker in the base currency paid to the Exchange executing the block trade
    /// </summary>
    [JsonProperty("execFee")]
    public decimal? Fee { get; set; }

    /// <summary>
    /// Block trade status. Processing, Filled, Rejected
    /// </summary>
    [JsonConverter(typeof(LabelConverter<BybitMovePositionStatus>))]
    public BybitMovePositionStatus Status { get; set; }

    /// <summary>
    /// The unique trade ID from the exchange
    /// </summary>
    [JsonProperty("execId")]
    public string ExecutionId { get; set; }

    /// <summary>
    /// The result code of the order. 0 means success
    /// </summary>
    public int ResultCode { get; set; }

    /// <summary>
    /// The error message. "" when resultCode=0
    /// </summary>
    public string ResultMessage { get; set; }

    /// <summary>
    /// The timestamp (ms) when the order is created
    /// </summary>
    [JsonProperty("createdAt")]
    public long CreateTimestamp { get; set; }

    /// <summary>
    /// The timestamp (ms) when the order is created
    /// </summary>
    public DateTime CreateTime { get => CreateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// The timestamp (ms) when the order is updated
    /// </summary>
    [JsonProperty("updatedAt")]
    public long UpdateTimestamp { get; set; }

    /// <summary>
    /// The timestamp (ms) when the order is updated
    /// </summary>
    public DateTime UpdateTime { get => UpdateTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// "" means the status=Filled
    /// Taker, Maker when status=Rejected
    /// bybit means error is occurred on the Bybit side
    /// </summary>
    public string RejectParty { get; set; }
}