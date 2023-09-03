namespace Bybit.Api;

public class BybitStreamClientOptions : WebSocketApiClientOptions
{
    // Demo
    public bool DemoTradingService { get; set; } = false;

    // Endpoints
    public string WebSocketSpotAddress { get; set; }
    public string WebSocketPerpetualAddress { get; set; }
    public string WebSocketInverseAddress { get; set; }
    public string WebSocketOptionAddress { get; set; }
    public string WebSocketPrivateAddress { get; set; }

    // Heartbeat
    public TimeSpan PingInterval { get; set; }

    public BybitStreamClientOptions()
    {
        this.WebSocketSpotAddress = BybitApiAddresses.MainNet.WebSocketSpotAddress;
        this.WebSocketPerpetualAddress = BybitApiAddresses.MainNet.WebSocketPerpetualAddress;
        this.WebSocketInverseAddress = BybitApiAddresses.MainNet.WebSocketInverseAddress;
        this.WebSocketOptionAddress = BybitApiAddresses.MainNet.WebSocketOptionAddress;
        this.WebSocketPrivateAddress = BybitApiAddresses.MainNet.WebSocketPrivateAddress;

        // Heartbeat
        this.PingInterval = TimeSpan.FromSeconds(20);
    }
}
