namespace Bybit.Api.Sbe;

/// <summary>
/// SBE orderbook level.
/// </summary>
public record BybitSbeOrderBookLevel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeOrderBookLevel"/> record.
    /// </summary>
    public BybitSbeOrderBookLevel(long priceMantissa, long sizeMantissa, sbyte priceExponent, sbyte sizeExponent)
    {
        PriceMantissa = priceMantissa;
        SizeMantissa = sizeMantissa;
        PriceExponent = priceExponent;
        SizeExponent = sizeExponent;
    }

    /// <summary>
    /// Price mantissa.
    /// </summary>
    public long PriceMantissa { get; }

    /// <summary>
    /// Size mantissa.
    /// </summary>
    public long SizeMantissa { get; }

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
