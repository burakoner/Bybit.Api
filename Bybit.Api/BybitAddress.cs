namespace Bybit.Api;

/// <summary>
/// Bybit Address
/// </summary>
public class BybitAddress
{
    /// <summary>
    /// Rest API Address
    /// </summary>
    public string RestApiAddress { get; set; }

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
    /// MainNet Environment
    /// </summary>
    public static BybitAddress MainNet = new()
    {
        RestApiAddress = "https://api.bybit.com",
        WebSocketSpotAddress = "wss://stream.bybit.com/v5/public/spot",
        WebSocketPerpetualAddress = "wss://stream.bybit.com/v5/public/linear",
        WebSocketInverseAddress = "wss://stream.bybit.com/v5/public/inverse",
        WebSocketOptionAddress = "wss://stream.bybit.com/v5/public/option",
        WebSocketPrivateAddress = "wss://stream.bybit.com/v5/private",
    };

    /// <summary>
    /// TestNet Environment
    /// </summary>
    public static BybitAddress TestNet = new()
    {
        RestApiAddress = "https://api-testnet.bybit.com",
        WebSocketSpotAddress = "wss://stream-testnet.bybit.com/v5/public/spot",
        WebSocketPerpetualAddress = "wss://stream-testnet.bybit.com/v5/public/linear",
        WebSocketInverseAddress = "wss://stream-testnet.bybit.com/v5/public/inverse",
        WebSocketOptionAddress = "wss://stream-testnet.bybit.com/v5/public/option",
        WebSocketPrivateAddress = "wss://stream-testnet.bybit.com/v5/private",
    };
    
    /// <summary>
    /// Bytick Environment
    /// </summary>
    public static BybitAddress Bytick = new()
    {
        RestApiAddress = "https://api.bytick.com",
        WebSocketSpotAddress = "wss://stream.bybit.com/v5/public/spot",
        WebSocketPerpetualAddress = "wss://stream.bybit.com/v5/public/linear",
        WebSocketInverseAddress = "wss://stream.bybit.com/v5/public/inverse",
        WebSocketOptionAddress = "wss://stream.bybit.com/v5/public/option",
        WebSocketPrivateAddress = "wss://stream.bybit.com/v5/private",
    };
}
