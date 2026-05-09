namespace Bybit.Api.Position;

/// <summary>
/// Switch position mode request.
/// </summary>
public record BybitPositionSwitchPositionModeRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionSwitchPositionModeRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    /// <param name="mode">Position mode.</param>
    public BybitPositionSwitchPositionModeRequest(BybitCategory category, BybitPositionMode mode)
    {
        Category = category;
        Mode = mode;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Position mode.
    /// </summary>
    public BybitPositionMode Mode { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Coin.
    /// </summary>
    public string? Asset { get; set; }
}
