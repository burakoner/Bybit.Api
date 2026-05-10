namespace Bybit.Api.Sbe;

/// <summary>
/// Bybit SBE constants.
/// </summary>
public static class BybitSbeConstants
{
    /// <summary>
    /// Market data SBE schema ID.
    /// </summary>
    public const ushort MarketSchemaId = 1;

    /// <summary>
    /// Market data SBE schema version.
    /// </summary>
    public const ushort MarketVersion = 0;

    /// <summary>
    /// Order entry SBE schema ID.
    /// </summary>
    public const ushort TradeSchemaId = 2;

    /// <summary>
    /// Order entry SBE schema version.
    /// </summary>
    public const ushort TradeVersion = 1;

    /// <summary>
    /// BBO RPI event template ID.
    /// </summary>
    public const ushort BestOrderBookRpiTemplateId = 20000;

    /// <summary>
    /// Level 50 orderbook event template ID.
    /// </summary>
    public const ushort Level50OrderBookTemplateId = 20001;

    /// <summary>
    /// Public trade event template ID.
    /// </summary>
    public const ushort PublicTradeTemplateId = 20002;

    /// <summary>
    /// Auth request template ID.
    /// </summary>
    public const ushort AuthRequestTemplateId = 1;

    /// <summary>
    /// Auth response template ID.
    /// </summary>
    public const ushort AuthResponseTemplateId = 2;

    /// <summary>
    /// Ping request template ID.
    /// </summary>
    public const ushort PingRequestTemplateId = 3;

    /// <summary>
    /// Pong response template ID.
    /// </summary>
    public const ushort PongResponseTemplateId = 4;

    /// <summary>
    /// Create order request template ID.
    /// </summary>
    public const ushort CreateOrderRequestTemplateId = 5;

    /// <summary>
    /// Create order response template ID.
    /// </summary>
    public const ushort CreateOrderResponseTemplateId = 6;

    /// <summary>
    /// Replace order request template ID.
    /// </summary>
    public const ushort ReplaceOrderRequestTemplateId = 7;

    /// <summary>
    /// Replace order response template ID.
    /// </summary>
    public const ushort ReplaceOrderResponseTemplateId = 8;

    /// <summary>
    /// Cancel order request template ID.
    /// </summary>
    public const ushort CancelOrderRequestTemplateId = 9;

    /// <summary>
    /// Cancel order response template ID.
    /// </summary>
    public const ushort CancelOrderResponseTemplateId = 10;

    /// <summary>
    /// Batch create order request template ID.
    /// </summary>
    public const ushort BatchCreateOrderRequestTemplateId = 11;

    /// <summary>
    /// Batch create order response template ID.
    /// </summary>
    public const ushort BatchCreateOrderResponseTemplateId = 12;

    /// <summary>
    /// Batch replace order request template ID.
    /// </summary>
    public const ushort BatchReplaceOrderRequestTemplateId = 13;

    /// <summary>
    /// Batch replace order response template ID.
    /// </summary>
    public const ushort BatchReplaceOrderResponseTemplateId = 14;

    /// <summary>
    /// Batch cancel order request template ID.
    /// </summary>
    public const ushort BatchCancelOrderRequestTemplateId = 15;

    /// <summary>
    /// Batch cancel order response template ID.
    /// </summary>
    public const ushort BatchCancelOrderResponseTemplateId = 16;

    /// <summary>
    /// Common error response template ID.
    /// </summary>
    public const ushort CommonErrorResponseTemplateId = 17;
}
