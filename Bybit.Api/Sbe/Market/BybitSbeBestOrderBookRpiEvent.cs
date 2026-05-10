namespace Bybit.Api.Sbe;

/// <summary>
/// SBE BBO RPI event.
/// </summary>
public record BybitSbeBestOrderBookRpiEvent
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
    /// Best ask normal price mantissa.
    /// </summary>
    public long AskNormalPriceMantissa { get; set; }

    /// <summary>
    /// Best ask normal size mantissa.
    /// </summary>
    public long AskNormalSizeMantissa { get; set; }

    /// <summary>
    /// Best RPI ask price mantissa.
    /// </summary>
    public long AskRpiPriceMantissa { get; set; }

    /// <summary>
    /// Best RPI ask size mantissa.
    /// </summary>
    public long AskRpiSizeMantissa { get; set; }

    /// <summary>
    /// Best bid normal price mantissa.
    /// </summary>
    public long BidNormalPriceMantissa { get; set; }

    /// <summary>
    /// Best bid normal size mantissa.
    /// </summary>
    public long BidNormalSizeMantissa { get; set; }

    /// <summary>
    /// Best RPI bid price mantissa.
    /// </summary>
    public long BidRpiPriceMantissa { get; set; }

    /// <summary>
    /// Best RPI bid size mantissa.
    /// </summary>
    public long BidRpiSizeMantissa { get; set; }

    /// <summary>
    /// Price exponent.
    /// </summary>
    public sbyte PriceExponent { get; set; }

    /// <summary>
    /// Size exponent.
    /// </summary>
    public sbyte SizeExponent { get; set; }

    /// <summary>
    /// Trading pair.
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Whether the frame contained separate RPI price fields.
    /// </summary>
    public bool HasSeparateRpiPrices { get; set; }

    /// <summary>
    /// Best ask normal price.
    /// </summary>
    public decimal AskNormalPrice { get => BybitSbeDecimal64.ApplyMarketExponent(AskNormalPriceMantissa, PriceExponent); }

    /// <summary>
    /// Best ask normal size.
    /// </summary>
    public decimal AskNormalSize { get => BybitSbeDecimal64.ApplyMarketExponent(AskNormalSizeMantissa, SizeExponent); }

    /// <summary>
    /// Best RPI ask price.
    /// </summary>
    public decimal AskRpiPrice { get => BybitSbeDecimal64.ApplyMarketExponent(AskRpiPriceMantissa, PriceExponent); }

    /// <summary>
    /// Best RPI ask size.
    /// </summary>
    public decimal AskRpiSize { get => BybitSbeDecimal64.ApplyMarketExponent(AskRpiSizeMantissa, SizeExponent); }

    /// <summary>
    /// Best bid normal price.
    /// </summary>
    public decimal BidNormalPrice { get => BybitSbeDecimal64.ApplyMarketExponent(BidNormalPriceMantissa, PriceExponent); }

    /// <summary>
    /// Best bid normal size.
    /// </summary>
    public decimal BidNormalSize { get => BybitSbeDecimal64.ApplyMarketExponent(BidNormalSizeMantissa, SizeExponent); }

    /// <summary>
    /// Best RPI bid price.
    /// </summary>
    public decimal BidRpiPrice { get => BybitSbeDecimal64.ApplyMarketExponent(BidRpiPriceMantissa, PriceExponent); }

    /// <summary>
    /// Best RPI bid size.
    /// </summary>
    public decimal BidRpiSize { get => BybitSbeDecimal64.ApplyMarketExponent(BidRpiSizeMantissa, SizeExponent); }
}
