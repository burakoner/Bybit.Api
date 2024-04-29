namespace Bybit.Api.Models.Account;

public class BybitDelayedWithdrawal
{
    [JsonProperty("limitAmountUsd")]
    public decimal LimitQuantityUsd { get; set; }

    [JsonProperty("withdrawableAmount")]
    public BybitDelayedWithdrawalQuantities WithdrawableQuantities { get; set; }
}

public class BybitDelayedWithdrawalQuantities
{
    public BybitDelayedWithdrawalQuantity Spot { get; set; }
    public BybitDelayedWithdrawalQuantity Fund { get; set; }
}

public class BybitDelayedWithdrawalQuantity
{
    [JsonProperty("coin")]
    public string Asset { get; set; }

    [JsonProperty("withdrawableAmount")]
    public decimal WithdrwawableQuantity { get; set; }

    public decimal AvailableBalance { get; set; }
}
