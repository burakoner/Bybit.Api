namespace Bybit.Api.Models.Margin;

public class BybitSpotBorrowOrder
{
    [JsonProperty("id")]
    public string BorrowId { get; set; }
    public string AccountId { get; set; }

    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("createdTime")]
    public long CreatedTimestamp { get; set; }
    public DateTime CreatedTime { get => CreatedTimestamp.ConvertFromMilliseconds(); }

    public decimal InterestAmount { get; set; }
    public decimal InterestBalance { get; set; }
    public decimal LoanAmount { get; set; }
    public decimal LoanBalance { get; set; }
    public decimal RemainAmount { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitSpotBorrowOrderType>))]
    public BybitSpotBorrowOrderType Type { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitSpotBorrowOrderStatus>))]
    public BybitSpotBorrowOrderStatus Status { get; set; }
}



