namespace Bybit.Api.Models.Trade;

/// <summary>
/// Borrow quota model.
/// </summary>
public class BybitBorrowQuota
{
    /// <summary>
    /// Symbol
    /// </summary>
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    /// <summary>
    /// Side
    /// </summary>
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

    /// <summary>
    /// No matter your Spot margin switch on or not, it always returns actual qty of base coin you can trade or you have, up to 4 decimals
    /// </summary>
    [JsonProperty("spotMaxTradeQty")]
    public decimal SpotMaximumTradeQuantity { get; set; }

    /// <summary>
    /// No matter your Spot margin switch on or not, it always returns actual amount of quote coin you can trade or you have, up to 8 decimals
    /// </summary>
    [JsonProperty("spotMaxTradeAmount")]
    public decimal SpotMaximumTradeAmount { get; set; }

    /// <summary>
    /// Borrow Coin
    /// </summary>
    [JsonProperty("borrowCoin")]
    public string BorrowCoin { get; set; }
}