namespace Bybit.Api.Models.Lending;

internal class BybitLendingLoanOrderContainer
{
    [JsonProperty("loanInfo")]
    public IEnumerable<BybitLendingLoanOrder> Payload { get; set; }
}

public class BybitLendingLoanOrder
{
    public string OrderId { get; set; }
    public string OrderProductId { get; set; }
    public long ParentUID { get; set; }

    [JsonProperty("loanTime")]
    public long LoanTimestamp { get; set; }
    public DateTime LoanTime { get => LoanTimestamp.ConvertFromMilliseconds(); }

    [JsonProperty("loanCoin")]
    public string LoanAsset { get; set; }

    public decimal LoanAmount { get; set; }
    public decimal UnpaidAmount { get; set; }
    public decimal UnpaidInterest { get; set; }
    public decimal RepaidAmount { get; set; }
    public decimal RepaidInterest { get; set; }
    public decimal InterestRate { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitLendingOrderStatus>))]
    public BybitLendingOrderStatus Status { get; set; }

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