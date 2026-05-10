namespace Bybit.Api.Sbe;

/// <summary>
/// SBE Decimal64 value.
/// </summary>
public readonly struct BybitSbeDecimal64
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeDecimal64"/> struct.
    /// </summary>
    public BybitSbeDecimal64(sbyte exponent, long mantissa)
    {
        Exponent = exponent;
        Mantissa = mantissa;
    }

    /// <summary>
    /// Power of 10.
    /// </summary>
    public sbyte Exponent { get; }

    /// <summary>
    /// Significand.
    /// </summary>
    public long Mantissa { get; }

    /// <summary>
    /// Actual value.
    /// </summary>
    public decimal Value { get => ApplyDecimalExponent(Mantissa, Exponent); }

    /// <summary>
    /// Create a Decimal64 from a decimal value and explicit exponent.
    /// </summary>
    public static BybitSbeDecimal64 FromDecimal(decimal value, sbyte exponent)
    {
        var mantissaDecimal = exponent >= 0
            ? value / Pow10(exponent)
            : value * Pow10(-exponent);

        if (mantissaDecimal != decimal.Truncate(mantissaDecimal))
            throw new ArgumentException("Value cannot be represented exactly with the specified exponent.", nameof(value));

        return new BybitSbeDecimal64(exponent, checked((long)mantissaDecimal));
    }

    /// <summary>
    /// Apply Decimal64 exponent semantics: value = mantissa * 10^exponent.
    /// </summary>
    public static decimal ApplyDecimalExponent(long mantissa, sbyte exponent)
    {
        return exponent >= 0
            ? mantissa * Pow10(exponent)
            : mantissa / Pow10(-exponent);
    }

    /// <summary>
    /// Apply market-data exponent semantics where positive exponents represent decimal places.
    /// </summary>
    public static decimal ApplyMarketExponent(long mantissa, sbyte exponent)
    {
        return exponent >= 0
            ? mantissa / Pow10(exponent)
            : mantissa * Pow10(-exponent);
    }

    private static decimal Pow10(int exponent)
    {
        var result = 1m;
        for (var i = 0; i < exponent; i++)
            result *= 10m;

        return result;
    }
}
