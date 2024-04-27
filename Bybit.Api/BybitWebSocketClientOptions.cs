namespace Bybit.Api;

/// <summary>
/// Bybit WebSocket Client Options
/// </summary>
public class BybitWebSocketClientOptions : WebSocketApiClientOptions
{
    /// <summary>
    /// WebSocket Spot Address
    /// </summary>
    public string WebSocketSpotAddress { get; set; }

    /// <summary>
    /// WebSocket Perpetual Address
    /// </summary>
    public string WebSocketPerpetualAddress { get; set; }

    /// <summary>
    /// WebSocket Inverse Address
    /// </summary>
    public string WebSocketInverseAddress { get; set; }

    /// <summary>
    /// WebSocket Option Address
    /// </summary>
    public string WebSocketOptionAddress { get; set; }

    /// <summary>
    /// WebSocket Private Address
    /// </summary>
    public string WebSocketPrivateAddress { get; set; }

    /// <summary>
    /// Heart Beat Interval
    /// </summary>
    public TimeSpan PingInterval { get; set; }

    /// <summary>
    /// Creates an instance of Bybit WebSocket Client Options
    /// </summary>
    public BybitWebSocketClientOptions()
    {
        this.WebSocketSpotAddress = BybitAddress.MainNet.WebSocketSpotAddress;
        this.WebSocketPerpetualAddress = BybitAddress.MainNet.WebSocketPerpetualAddress;
        this.WebSocketInverseAddress = BybitAddress.MainNet.WebSocketInverseAddress;
        this.WebSocketOptionAddress = BybitAddress.MainNet.WebSocketOptionAddress;
        this.WebSocketPrivateAddress = BybitAddress.MainNet.WebSocketPrivateAddress;

        // Heartbeat
        this.PingInterval = TimeSpan.FromSeconds(20);
    }
}
