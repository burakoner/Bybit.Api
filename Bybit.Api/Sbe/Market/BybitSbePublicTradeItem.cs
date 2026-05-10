namespace Bybit.Api.Sbe;

/// <summary>
/// SBE public trade item.
/// </summary>
public record BybitSbePublicTradeItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbePublicTradeItem"/> record.
    /// </summary>
    public BybitSbePublicTradeItem(long fillTimeMicroseconds, long priceMantissa, long sizeMantissa, long sequence, BybitSbeSide side, BybitSbeBool isBlockTrade, BybitSbeBool isRpi, string executionId, sbyte priceExponent, sbyte sizeExponent)
    {
        FillTimeMicroseconds = fillTimeMicroseconds;
        PriceMantissa = priceMantissa;
        SizeMantissa = sizeMantissa;
        Sequence = sequence;
        Side = side;
        IsBlockTrade = isBlockTrade;
        IsRpi = isRpi;
        ExecutionId = executionId;
        PriceExponent = priceExponent;
        SizeExponent = sizeExponent;
    }

    /// <summary>
    /// Trade fill timestamp in microseconds.
    /// </summary>
    public long FillTimeMicroseconds { get; }

    /// <summary>
    /// Price mantissa.
    /// </summary>
    public long PriceMantissa { get; }

    /// <summary>
    /// Size mantissa.
    /// </summary>
    public long SizeMantissa { get; }

    /// <summary>
    /// Cross sequence ID.
    /// </summary>
    public long Sequence { get; }

    /// <summary>
    /// Taker side.
    /// </summary>
    public BybitSbeSide Side { get; }

    /// <summary>
    /// Whether this is a block trade.
    /// </summary>
    public BybitSbeBool IsBlockTrade { get; }

    /// <summary>
    /// Whether this is an RPI trade.
    /// </summary>
    public BybitSbeBool IsRpi { get; }

    /// <summary>
    /// Trade ID.
    /// </summary>
    public string ExecutionId { get; }

    /// <summary>
    /// Price exponent.
    /// </summary>
    public sbyte PriceExponent { get; }

    /// <summary>
    /// Size exponent.
    /// </summary>
    public sbyte SizeExponent { get; }

    /// <summary>
    /// Price.
    /// </summary>
    public decimal Price { get => BybitSbeDecimal64.ApplyMarketExponent(PriceMantissa, PriceExponent); }

    /// <summary>
    /// Size.
    /// </summary>
    public decimal Size { get => BybitSbeDecimal64.ApplyMarketExponent(SizeMantissa, SizeExponent); }
}
