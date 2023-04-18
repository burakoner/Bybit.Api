namespace Bybit.Api.Models.Market;

public class BybitOpenInterest
{
    public decimal OpenInterest { get; set; }
    public long Timestamp { get; set; }
    public DateTime Time { get => Timestamp.ConvertFromMilliseconds(); }
}