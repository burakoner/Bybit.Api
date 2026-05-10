namespace Bybit.Api.Sbe;

/// <summary>
/// SBE Level 50 orderbook event.
/// </summary>
public record BybitSbeLevel50OrderBookEvent
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
    /// Cross sequence ID.
    /// </summary>
    public long Sequence { get; set; }

    /// <summary>
    /// Matching-engine creation timestamp in microseconds.
    /// </summary>
    public long CreationTimestampMicroseconds { get; set; }

    /// <summary>
    /// Update ID.
    /// </summary>
    public long UpdateId { get; set; }

    /// <summary>
    /// Price exponent.
    /// </summary>
    public sbyte PriceExponent { get; set; }

    /// <summary>
    /// Size exponent.
    /// </summary>
    public sbyte SizeExponent { get; set; }

    /// <summary>
    /// Package type.
    /// </summary>
    public BybitSbePackageType PackageType { get; set; }

    /// <summary>
    /// Ask updates.
    /// </summary>
    public List<BybitSbeOrderBookLevel> Asks { get; set; } = [];

    /// <summary>
    /// Bid updates.
    /// </summary>
    public List<BybitSbeOrderBookLevel> Bids { get; set; } = [];

    /// <summary>
    /// Trading pair.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;
}
