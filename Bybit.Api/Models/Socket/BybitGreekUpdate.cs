namespace Bybit.Api.Models.Socket;

public class BybitGreekUpdate
{
    public string BaseCoin { get; set; }
    public decimal? TotalDelta { get; set; }
    public decimal? TotalGamma { get; set; }
    public decimal? TotalVega { get; set; }
    public decimal? TotalTheta { get; set; }
}