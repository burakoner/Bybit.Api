namespace Bybit.Api.Models.Trading;

public class BybitBorrowQuota
{
    [JsonProperty("symbol")]
    public string Symbol { get; set; }

    [JsonProperty("symbol")]
    public string BorrowCoin { get; set; }

    [JsonProperty("side"), JsonConverter(typeof(LabelConverter<BybitOrderSide>))]
    public BybitOrderSide Side { get; set; }

    /// <summary>
    /// The maximum base coin qty can be traded
    /// - If spot margin trade on and symbol is margin trading pair, it returns available balance + max.borrowable amount
    /// - Otherwise, it returns actual balance
    /// </summary>
    [JsonProperty("maxTradeQty")]
    public decimal MaximumTradeQuantity { get; set; }

    /// <summary>
    /// The maximum quote coin amount can be traded
    /// - If spot margin trade on and symbol is margin trading pair, it returns available balance + max.borrowable amount
    /// - Otherwise, it returns actual balance
    /// </summary>
    [JsonProperty("maxTradeAmount")]
    public decimal MaximumTradeAmount { get; set; }
}