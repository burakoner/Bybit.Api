namespace Bybit.Api.Models.Lending;

internal class BybitLendingProductContainer
{
    [JsonProperty("marginProductInfo")]
    public IEnumerable<BybitLendingProduct> Payload { get; set; }
}

public class BybitLendingProduct
{
    public string ProductId { get; set; }
    public decimal Leverage { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool SupportSpot { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool SupportContract { get; set; }

    public decimal WithdrawLine { get; set; }
    public decimal TransferLine { get; set; }
    public decimal SpotBuyLine { get; set; }
    public decimal SpotSellLine { get; set; }
    public decimal ContractOpenLine { get; set; }
    public decimal LiquidationLine { get; set; }
    public decimal StopLiquidationLine { get; set; }
    public decimal ContractLeverage { get; set; }
    public decimal TransferRatio { get; set; }
    public IEnumerable<string> SpotSymbols { get; set; }
    public IEnumerable<string> ContractSymbols { get; set; }
}