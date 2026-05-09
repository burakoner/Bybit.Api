namespace Bybit.Api.Account;

/// <summary>
/// Bybit account trade behavior configuration.
/// </summary>
public record BybitAccountUserSettingConfig
{
    /// <summary>
    /// Whether spot limit price protection is enabled.
    /// </summary>
    public bool LpaSpot { get; set; }

    /// <summary>
    /// Whether perpetual limit price protection is enabled.
    /// </summary>
    public bool LpaPerp { get; set; }

    /// <summary>
    /// Whether delta neutral mode is enabled.
    /// </summary>
    public bool? DeltaEnable { get; set; }

    /// <summary>
    /// Whether spot market spread enhancement is enabled.
    /// </summary>
    public bool Smsef { get; set; }

    /// <summary>
    /// Whether futures market spread enhancement is enabled.
    /// </summary>
    public bool Fmsef { get; set; }
}
