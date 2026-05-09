namespace Bybit.Api.Account;

/// <summary>
/// Bybit account batch set collateral coin result item.
/// </summary>
public record BybitAccountBatchSetCollateralResult
{
    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; } = string.Empty;

    /// <summary>
    /// Collateral switch status.
    /// </summary>
    public BybitSwitchStatus CollateralSwitch { get; set; }
}
