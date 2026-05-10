namespace Bybit.Api;

/// <summary>
/// Bybit Address
/// </summary>
public class BybitAddress
{
    /// <summary>
    /// Rest API Address
    /// </summary>
    public string RestApiAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Spot Address
    /// </summary>
    public string WebSocketSpotAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Perpetual Address
    /// </summary>
    public string WebSocketPerpetualAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Inverse Address
    /// </summary>
    public string WebSocketInverseAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Option Address
    /// </summary>
    public string WebSocketOptionAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Private Address
    /// </summary>
    public string WebSocketPrivateAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Spread Address
    /// </summary>
    public string WebSocketSpreadAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket RFQ Address
    /// </summary>
    public string WebSocketRfqAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket Order Entry Address
    /// </summary>
    public string WebSocketTradeAddress { get; set; } = string.Empty;

    /// <summary>
    /// WebSocket System Status Address
    /// </summary>
    public string WebSocketSystemStatusAddress { get; set; } = string.Empty;

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
        WebSocketSpreadAddress = "wss://stream.bybit.com/v5/public/spread",
        WebSocketRfqAddress = "wss://stream.bybit.com/v5/public/rfq",
        WebSocketTradeAddress = "wss://stream.bybit.com/v5/trade",
        WebSocketSystemStatusAddress = "wss://stream.bybit.com/v5/public/misc/status",
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
        WebSocketSpreadAddress = "wss://stream-testnet.bybit.com/v5/public/spread",
        WebSocketRfqAddress = "wss://stream-testnet.bybit.com/v5/public/rfq",
        WebSocketTradeAddress = "wss://stream-testnet.bybit.com/v5/trade",
        WebSocketSystemStatusAddress = "wss://stream-testnet.bybit.com/v5/public/misc/status",
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
        WebSocketSpreadAddress = "wss://stream.bybit.com/v5/public/spread",
        WebSocketRfqAddress = "wss://stream.bybit.com/v5/public/rfq",
        WebSocketTradeAddress = "wss://stream.bybit.com/v5/trade",
        WebSocketSystemStatusAddress = "wss://stream.bybit.com/v5/public/misc/status",
    };
}
