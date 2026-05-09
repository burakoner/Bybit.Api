namespace Bybit.Api.Account;

/// <summary>
/// Bybit account disconnect-cancel-all information.
/// </summary>
public record BybitAccountDcpInfo
{
    /// <summary>
    /// Product scope.
    /// </summary>
    public BybitDcpProduct Product { get; set; }

    /// <summary>
    /// Disconnect-cancel-all status.
    /// </summary>
    public BybitSwitchStatus DcpStatus { get; set; }

    /// <summary>
    /// Disconnect-cancel-all time window in seconds.
    /// </summary>
    public int TimeWindow { get; set; }
}

/// <summary>
/// Bybit account disconnect-cancel-all information result.
/// </summary>
internal record BybitAccountDcpInfoResult
{
    /// <summary>
    /// Disconnect-cancel-all information.
    /// </summary>
    public List<BybitAccountDcpInfo> DcpInfos { get; set; } = [];
}
