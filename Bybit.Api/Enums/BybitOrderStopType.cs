namespace Bybit.Api.Enums;

public enum BybitOrderStopType
{
    [Label("TakeProfit")]
    TakeProfit,

    [Label("StopLoss")]
    StopLoss,

    [Label("TrailingStop")]
    TrailingStop,

    [Label("Stop")]
    Stop,

    [Label("PartialTakeProfit")]
    PartialTakeProfit,

    [Label("PartialStopLoss")]
    PartialStopLoss,

    [Label("tpslOrder")]
    TakeProfitStopLossOrder,
}