namespace Bybit.Api.Trading;

/// <summary>
/// Set disconnect cancel all request.
/// </summary>
public record BybitSetDisconnectProtectionRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSetDisconnectProtectionRequest"/> record.
    /// </summary>
    /// <param name="timeWindow">Disconnection timing window in seconds.</param>
    public BybitSetDisconnectProtectionRequest(int timeWindow)
    {
        TimeWindow = timeWindow;
    }

    /// <summary>
    /// Product scope. If omitted, Bybit defaults to options.
    /// </summary>
    public BybitDcpProduct? Product { get; set; }

    /// <summary>
    /// Disconnection timing window in seconds.
    /// </summary>
    public int TimeWindow { get; set; }
}
