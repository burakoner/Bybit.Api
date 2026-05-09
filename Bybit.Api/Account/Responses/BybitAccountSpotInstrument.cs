using Bybit.Api.Market;

namespace Bybit.Api.Account;

/// <summary>
/// Bybit account spot instrument.
/// </summary>
public record BybitAccountSpotInstrument : BybitMarketSpotInstrument
{
    /// <summary>
    /// Whether the symbol is a public RPI orderbook symbol.
    /// </summary>
    public bool IsPublicRpi { get; set; }

    /// <summary>
    /// Whether the user has RPI permission for this symbol.
    /// </summary>
    public bool MyRpiPermission { get; set; }
}
