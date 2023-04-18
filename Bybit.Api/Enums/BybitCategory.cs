namespace Bybit.Api.Enums;

public enum BybitCategory
{
    [Label("spot")]
    Spot,

    [Label("linear")]
    Linear,

    [Label("inverse")]
    Inverse,

    [Label("option")]
    Option,
}