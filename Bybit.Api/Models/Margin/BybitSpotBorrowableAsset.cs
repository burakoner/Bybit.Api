namespace Bybit.Api.Models.Margin;

public class BybitSpotBorrowableAsset
{
    [JsonProperty("coin")]
    public string Asset { get; set; }
    public int BorrowingPrecision { get; set; }
    public int RepaymentPrecision { get; set; }
}