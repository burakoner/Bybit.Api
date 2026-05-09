namespace Bybit.Api.Account;

/// <summary>
/// Bybit account batch set collateral coin request item.
/// </summary>
public record BybitAccountBatchSetCollateralItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountBatchSetCollateralItem"/> record.
    /// </summary>
    /// <param name="asset">Coin name.</param>
    /// <param name="collateralSwitch">Collateral switch status.</param>
    public BybitAccountBatchSetCollateralItem(string asset, BybitSwitchStatus collateralSwitch)
    {
        Asset = asset;
        CollateralSwitch = collateralSwitch;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    [JsonProperty("coin")]
    public string Asset { get; set; }

    /// <summary>
    /// Collateral switch status.
    /// </summary>
    [JsonProperty("collateralSwitch")]
    public BybitSwitchStatus CollateralSwitch { get; set; }
}
