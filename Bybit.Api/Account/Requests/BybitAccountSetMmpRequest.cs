namespace Bybit.Api.Account;

/// <summary>
/// Bybit account set market maker protection request.
/// </summary>
public record BybitAccountSetMmpRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountSetMmpRequest"/> record.
    /// </summary>
    /// <param name="baseAsset">Base coin.</param>
    /// <param name="window">Time window (ms).</param>
    /// <param name="frozenPeriod">Frozen period (ms).</param>
    /// <param name="quantityLimit">Trade quantity limit.</param>
    /// <param name="deltaLimit">Delta limit.</param>
    public BybitAccountSetMmpRequest(string baseAsset, int window, int frozenPeriod, decimal quantityLimit, decimal deltaLimit)
    {
        BaseAsset = baseAsset;
        Window = window;
        FrozenPeriod = frozenPeriod;
        QuantityLimit = quantityLimit;
        DeltaLimit = deltaLimit;
    }

    /// <summary>
    /// Base coin.
    /// </summary>
    public string BaseAsset { get; set; }

    /// <summary>
    /// Time window (ms).
    /// </summary>
    public int Window { get; set; }

    /// <summary>
    /// Frozen period (ms).
    /// </summary>
    public int FrozenPeriod { get; set; }

    /// <summary>
    /// Trade quantity limit.
    /// </summary>
    public decimal QuantityLimit { get; set; }

    /// <summary>
    /// Delta limit.
    /// </summary>
    public decimal DeltaLimit { get; set; }
}
