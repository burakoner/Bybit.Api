namespace Bybit.Api.Account;

/// <summary>
/// Bybit account set collateral coin request.
/// </summary>
public record BybitAccountSetCollateralRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountSetCollateralRequest"/> record.
    /// </summary>
    /// <param name="asset">Coin name.</param>
    /// <param name="collateralSwitch">Collateral switch status.</param>
    public BybitAccountSetCollateralRequest(string asset, BybitSwitchStatus collateralSwitch)
    {
        Asset = asset;
        CollateralSwitch = collateralSwitch;
    }

    /// <summary>
    /// Coin name.
    /// </summary>
    public string Asset { get; set; }

    /// <summary>
    /// Collateral switch status.
    /// </summary>
    public BybitSwitchStatus CollateralSwitch { get; set; }
}
