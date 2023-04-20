namespace Bybit.Api.Models.Margin;

public class BybitSpotInterestAndQuota
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("interestRate")]
    public decimal DailyInterestRate { get; set; }

    [JsonProperty("loanAbleAmount")]
    public decimal LoanableQuantity { get; set; }

    [JsonProperty("maxLoanAmount")]
    public decimal MaximumLoanQuantity { get; set; }
}