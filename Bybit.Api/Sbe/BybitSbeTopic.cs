namespace Bybit.Api.Sbe;

/// <summary>
/// Helpers for SBE topic and path values.
/// </summary>
public static class BybitSbeTopic
{
    /// <summary>
    /// Spot market SBE path suffix.
    /// </summary>
    public const string SpotMarketPath = "v5/public-sbe/spot";

    /// <summary>
    /// USDT/USDC contracts market SBE path suffix.
    /// </summary>
    public const string LinearMarketPath = "v5/public-sbe/linear";

    /// <summary>
    /// Coin-margin contracts market SBE path suffix.
    /// </summary>
    public const string InverseMarketPath = "v5/public-sbe/inverse";

    /// <summary>
    /// Order entry SBE path suffix.
    /// </summary>
    public const string TradePath = "v5/trade-sbe";

    /// <summary>
    /// Create BBO RPI topic.
    /// </summary>
    public static string BestBidOfferRpi(string symbol) => $"ob.rpi.1.sbe.{ValidateSymbol(symbol)}";

    /// <summary>
    /// Create Level 50 orderbook topic.
    /// </summary>
    public static string Level50OrderBook(string symbol) => $"ob.50.sbe.{ValidateSymbol(symbol)}";

    /// <summary>
    /// Create public trade topic.
    /// </summary>
    public static string PublicTrade(string symbol) => $"publicTrade.sbe.{ValidateSymbol(symbol)}";

    private static string ValidateSymbol(string symbol)
    {
        if (string.IsNullOrWhiteSpace(symbol))
            throw new ArgumentException("Symbol is required.", nameof(symbol));

        return symbol.Trim();
    }
}
