namespace Bybit.Api.Sbe;

/// <summary>
/// SBE public trade event.
/// </summary>
public record BybitSbePublicTradeEvent
{
    /// <summary>
    /// SBE message header.
    /// </summary>
    public BybitSbeMessageHeader Header { get; set; } = new(0, 0, 0, 0);

    /// <summary>
    /// System generation timestamp in microseconds.
    /// </summary>
    public long TimestampMicroseconds { get; set; }

    /// <summary>
    /// Price exponent.
    /// </summary>
    public sbyte PriceExponent { get; set; }

    /// <summary>
    /// Size exponent.
    /// </summary>
    public sbyte SizeExponent { get; set; }

    /// <summary>
    /// Trades.
    /// </summary>
    public List<BybitSbePublicTradeItem> Trades { get; set; } = [];

    /// <summary>
    /// Trading pair.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;
}
