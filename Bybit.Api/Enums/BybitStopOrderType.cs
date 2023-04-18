namespace Bybit.Api.Enums;

public enum BybitStopOrderType
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