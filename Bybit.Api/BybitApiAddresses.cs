namespace Bybit.Api;

public class BybitApiAddresses
{
    public string RestApiAddress { get; set; }
    public string WebSocketSpotAddress { get; set; }
    public string WebSocketPerpetualAddress { get; set; }
    public string WebSocketInverseAddress { get; set; }
    public string WebSocketOptionAddress { get; set; }
    public string WebSocketPrivateAddress { get; set; }

    public static BybitApiAddresses MainNet = new()
    {
        RestApiAddress = "https://api.bybit.com",
        WebSocketSpotAddress = "wss://stream.bybit.com/v5/public/spot",
        WebSocketPerpetualAddress = "wss://stream.bybit.com/v5/public/linear",
        WebSocketInverseAddress = "wss://stream.bybit.com/v5/public/inverse",
        WebSocketOptionAddress = "wss://stream.bybit.com/v5/public/option",
        WebSocketPrivateAddress = "wss://stream.bybit.com/v5/private",
    };

    public static BybitApiAddresses Bytick = new()
    {
        RestApiAddress = "https://api.bytick.com",
    };

    public static BybitApiAddresses TestNet = new()
    {
        RestApiAddress = "https://api-testnet.bybit.com",
        WebSocketSpotAddress = "wss://stream-testnet.bybit.com/v5/public/spot",
        WebSocketPerpetualAddress = "wss://stream-testnet.bybit.com/v5/public/linear",
        WebSocketInverseAddress = "wss://stream-testnet.bybit.com/v5/public/inverse",
        WebSocketOptionAddress = "wss://stream-testnet.bybit.com/v5/public/option",
        WebSocketPrivateAddress = "wss://stream-testnet.bybit.com/v5/private",
    };
}
